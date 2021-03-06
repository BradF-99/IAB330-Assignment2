const express = require('express');
const router = express.Router();
const Promise = require('bluebird')
const axios = require('axios')

const redisClient = require("../modules/redisHandler");

const JSONCache = require('redis-json');
const jsonCache = new JSONCache(redisClient, {
  prefix: ''
});

const csv = require('csvtojson');

router.get('/', function (req, res, next) {
  getData("[4-5]*",res);
});

router.get('/:query', function (req, res, next) {
  getData(req.params.query,res);
});

async function getData(query,res) {
  let keys = [];

  scanAsync(0, query, keys).then(function () {
      if (keys.length == 0) {
        pullData().then(function () {
          scanAsync(0, query, keys);
        });
      }
      returnData(keys, res);
    })
    .catch(function (err) {
      return res.json({
        "err": err
      })
    });
}

async function returnData(keys, res) {
  const fetchQueue = [];
  let parkingSpaces = [];

  for (key of keys) {
    fetchQueue.push(getHashData(key));
  }
  const results = await Promise.all(fetchQueue);
  for (const result of results) {
    parkingSpaces.push(result)
  }
  return res.json(JSON.stringify(parkingSpaces));
}

async function getHashData(key) {
  return new Promise(function (resolve, reject) {
    redisClient.hgetall(key, function (err, result) {
      if (err) {
        reject(err)
      } else {
        resolve(result)
      }
    });
  });
}

async function scanAsync(cursor, pattern, results) {
  return redisClient.scanAsync(cursor, 'MATCH', pattern, 'COUNT', '2000')
    .then(function (res) {
      let keys = res[1];
      keys.forEach(function (key) {
        results.push(key);
      })
      cursor = res[0];
      if (!cursor === '0') {
        return scanAsync(cursor, pattern, results);
      }
    });
}

async function pullData(res) {
  const dataURL = "https://www.data.brisbane.qld.gov.au/data/dataset/9378944d-2b4c-4b69-bd66-bc78088caab0/resource/fb42db12-7c82-40bb-8d3c-4f6119540edc/download/parking-meter-locations.csv"
  const dbQueue = [];

  const data = await axios.get(dataURL);
  const parkingMeters = await strToJson(data.data);
  parkingMeters.forEach(data => {
    key = data["METER_NO"];
    dbQueue.push(jsonCache.set(key, data));
  });
  await Promise.all(parkingMeters);
}

async function strToJson(csvString) {
  return new Promise(function (resolve, reject) {
    csv()
      .fromString(csvString)
      .then((json) => {
        resolve(json);
      })
      .catch(function (err) {
        reject(err);
      });
  });
}

module.exports = router;
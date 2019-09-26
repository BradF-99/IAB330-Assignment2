const express = require('express');
const path = require('path');
const cookieParser = require('cookie-parser');
const logger = require('morgan');

const indexRouter = require('./routes/index');
const dataRouter = require('./routes/dataRouter');

const redisClient = require("./modules/redisHandler");

const app = express();

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({
    extended: false
}));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use('/', indexRouter);
app.use('/data', dataRouter);

redisClient.on('connect', () => {
    console.log("Successfully connected to Redis Server, we're ready!");
});
redisClient.on('error', err => {
    console.log("Unable to connect to Redis, terminating.")
    console.log(`Error: ${err}`);
    process.exit(1);
});

module.exports = app;
# Dockerfile for IAB330 Assignment 2
# By Brad F, QUT
# n10147012
# Modified from CAB432 Assignment 1

FROM node:lts-alpine

ENV REDIS_URL //0.0.0.0:6379

RUN apk update && \
    apk add redis

RUN npm install -g concurrently

ADD . /app
EXPOSE 3000
WORKDIR /app
RUN chmod u+x ./bin/www

RUN npm i

CMD concurrently "/usr/bin/redis-server --bind '0.0.0.0'" "sleep 5s; ./bin/www"
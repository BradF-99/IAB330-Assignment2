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
EXPOSE 80
EXPOSE 443
WORKDIR /app
RUN npm i 
CMD concurrently "/usr/bin/redis-server --bind '0.0.0.0'" "sleep 5s; ./bin/www" 
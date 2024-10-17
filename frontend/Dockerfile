# base image
FROM node:latest

# set working directory
WORKDIR /frontend

# install and cache app dependencies
COPY ./package.json package.json
COPY ./vite.config.js vite.config.js

RUN npm install

# start app
CMD ["npm", "run", "dev", "--", "--host", "0.0.0.0"]
#!/bin/bash

# Container name
CONTAINER_NAME="mongodb"

# Port configuration (binds container's port 27017 to host's port 27017)
HOST_PORT=27017
CONTAINER_PORT=27017

# Volume for persistent data (optional: this stores data on the host)
VOLUME_NAME="mongo_data"
VOLUME_PATH="/data/db"

# Check if the container is already running
if [ "$(docker ps -q -f name=$CONTAINER_NAME)" ]; then
    echo "MongoDB container is already running."
    exit 0
fi

# Check if the container exists but is not running
if [ "$(docker ps -a -q -f name=$CONTAINER_NAME)" ]; then
    echo "Starting existing MongoDB container..."
    docker start $CONTAINER_NAME
else
    echo "Creating and running a new MongoDB container..."
    # Pull the MongoDB image and run the container with port mapping and volume for persistence
    docker run -d \
        --name $CONTAINER_NAME \
        -p $HOST_PORT:$CONTAINER_PORT \
        -v $VOLUME_NAME:$VOLUME_PATH \
        mongo
fi

echo "MongoDB is running. You can connect to it on localhost:$HOST_PORT."


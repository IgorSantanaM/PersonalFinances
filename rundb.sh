#!/bin/bash

# Check if MongoDB container is already running
if [ "$(docker ps -q -f name=mongodb-container)" ]; then
    echo "MongoDB container is already running."
else
    # Check if the MongoDB container exists but is stopped
    if [ "$(docker ps -aq -f name=mongodb-container)" ]; then
        echo "Starting MongoDB container..."
        docker start mongodb-container
    else
        echo "Running MongoDB container for the first time..."
        docker run --name mongodb-container -d -p 27017:27017 mongo
    fi
fi


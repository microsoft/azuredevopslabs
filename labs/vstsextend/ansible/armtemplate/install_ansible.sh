#!/bin/bash

## Update and upgrade the packages
sudo apt update && sudo apt dist-upgrade -y

## Install pre-requisite packages
sudo apt install -y libssl-dev libffi-dev python-dev python-pip

## Install Ansible and Azure SDK via pip
sudo pip install ansible[azure]

## Create a credentials file to store azure credentials
## sudo mkdir ~/.azure
## sudo touch ~/.azure/credentials
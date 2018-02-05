---
title: Setting up a Private VSTS Build Agent 
layout: page
sidebar: java
permalink: /labs/java/dockerbuildagent/
folder: /labs/java/dockerbuildagent/
comments: true
---

In this exercise, you are going to configure a private build agent that runs in a Docker container.

This exercise assumes you have completed the exercise to create a Team Project. This exercise uses a team project named **jdev-labs**, though your team project name may differ.

{% include note.html content= "It is not necessary to run the VSTS agent in a container - but it is convenient to do so and means that you don't have to install any other prerequisites on the machine running the container, since all the prerequisites are inside the container." %}

## Starting a VSTS Agent Container using Docker

In this task you will start a VSTS build agent container using Docker. This container will be used to run builds and releases.

1. On your VM, open a terminal by clicking on the Terminal Emulator icon in the toolbar.

    ![Click on the terminal icon in the Toolbar](images/click-terminal.png)

1. Enter the following command:

    ```sh
    docker run -e VSTS_ACCOUNT=<account> -e VSTS_TOKEN=<pat> -v /var/run/docker.sock:/var/run/docker.sock --name vstsagent -it vsts/agent
    ```

    where:
    - _account_ is your VSTS account name (the bit before .visualstudio.com)
    - _pat_ is your PAT

    You should see a message indicating **Listening for Jobs**:

    ![The agent container running](images/agent-container-running.png)

    {% include note.html content="This starts a docker container (called vstsagent) that has a VSTS agent running inside it. The agent is connected to your VSTS account and has also mounted the VM Docker socket so that the container can perform Docker operations (like building containers). It is created from a Dockerfile (listed below) that installs PhantomJS for running headless Selenium tests and configures Docker certs and environment variables. You can move this terminal to the side since the container is running interactively, so the prompt you are seeing is actually inside the container. Open a new terminal by clicking on the Terminal Emulator icon in the toolbar" %}

    ```dockerfile
    # Dockerfile for custom vsts agent image with phantomjd and docker config
    FROM microsoft/vsts-agent

    # install phantomjs
    RUN curl -L https://bitbucket.org/ariya/phantomjs/downloads/$PHANTOM.tar.bz2 > $PHANTOM.tar.bz2 && \
    tar xvjf $PHANTOM.tar.bz2 -C /usr/local/share && \
    ln -sf /usr/local/share/$PHANTOM/bin/phantomjs /usr/local/share/phantomjs && \
    ln -sf /usr/local/share/$PHANTOM/bin/phantomjs /usr/local/bin/phantomjs && \
    ln -sf /usr/local/share/$PHANTOM/bin/phantomjs /usr/bin/phantomjs
    RUN apt-get update && apt-get install libfontconfig -y

    # configure docker
    COPY .docker /root/.docker/
    ENV DOCKER_HOST=tcp://$HOSTNAME:2376 DOCKER_TLS_VERIFY=1
    ```

    > `$HOSTNAME` is a variable that resolves in the setup script that executed when you set up your Azure VM.

1. If your container stops running for some reason, you can run the following commands to restart and attach to it:
    ```sh
    docker start vstsagent
    docker attach vstsagent
    ```
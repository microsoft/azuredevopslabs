## Introduction to Docker and Kubernetes terminology

[**Docker**](https://www.docker.com/){:target="_blank"}: Docker is a software technology, that provides operating-system-level virtualization to easily deploy applications in a sandbox (called containers) to run on the Linux.

[**Images**](https://docs.docker.com/engine/docker-overview/#docker-objects){:target="_blank"}: An image is a read-only template, with the necessary instructions required for the application to run.

[**Containers**](https://docs.docker.com/engine/docker-overview/#docker-objects){:target="_blank"}: Provides an isolated environment in which an app along with its environment is being run.

[**Kubernetes**](https://kubernetes.io/){:target="_blank"}: Kubernetes is an open source system for managing containerized applications across multiple hosts, providing basic mechanisms for deployment, maintenance, and scaling of applications.

[**Pods**](https://kubernetes.io/docs/concepts/workloads/pods/pod/){:target="_blank"}: A Pod is the basic building block of Kubernetes and represents a executable unit of the work. A Pod usually contains a single container.

[**Services**](https://kubernetes.io/docs/concepts/services-networking/service/){:target="_blank"}: A service tells other pods about the services that your application provides.

[**Deployments**](https://kubernetes.io/docs/concepts/workloads/controllers/deployment/){:target="_blank"}: A Deployment controller provides declarative updates for Pods

[**Kubernetes Manifest file**](https://kubernetes.io/docs/reference/kubectl/cheatsheet/){:target="_blank"}: Kubernetes manifests with deployments, whereas services and pods can be defined in json or yaml. The file extensions .yaml, .yml, and .json can be used.
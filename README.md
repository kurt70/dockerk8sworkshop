# Docker
This part of the workshop will give a light introduction to the docker containerization technology.

Docker´s architecture consists of 3 entities, which are the docker client, a docker deamon and a docker registry. 

Both the client and the deamon, which make up the docker engine, are running on your local machine, while a registry is either running on a private or public network. 

Dockerhub is for instance a registry on a public network.

The client is the command line tool you are using to issue docker commands. 

The commands in turn issue HTTP requests to the docker deamon.      
 
## step 1: Hello World 
This exercise will be to pull down an image from dockerhub and run it locally. In any terminal of your choice, simply write:   

```dockerfile
docker pull hello-world
docker run hello-world
```
You should now see the following text in the terminal:

Hello from Docker!
This message shows that your installation appears to be working correctly.

...


It also informs us about what Docker did for us just now:

 1. The Docker client contacted the Docker daemon.
 2. The Docker daemon pulled the "hello-world" image from the Docker Hub.
    (amd64)
 3. The Docker daemon created a new container from that image which runs the
    executable that produces the output you are currently reading.
 4. The Docker daemon streamed that output to the Docker client, which sent it
    to your terminal. 

Notice that it downloads a set of layers that make up the image.


### Common cases
#### Running an interactive session
An interactive session, starting at the bash terminal, can be created for those images that have the shell installed
```dockerfile
docker run -it ubuntu bash
```

Notice that since we did not have the ubuntu image locally it did an implicit pull of that image for us. 

### List downloaded images
```dockerfile
 docker images
```
### List containers 
```dockerfile
 docker ps or docker container ls
```
### kill container 
```dockerfile
 docker kill [CONTAINER ID]
```
### Running a container as background process 
```dockerfile
 docker run -d [image]
```

### Step two : Build an image
Images are created from Dockerfiles, where steps for creating your own image is done on top of a base image. 

In this project (/WebAppTest/) we find a Dockerfile that uses two separate base images. 

This is known as a multistage dockerfile.

The first base image has a complete sdk installed, while the second base image is slimmer in size and reduces the attack surface. 

* Go to the folder where the dockerfile is (WebAppTest)
* build docker file and tag it
* Run it with port mapping 
```dockerfile
   docker build . -t webapptest:latest
   docker run -p 1880:1880 webapptest
```  

Docker tags convey useful information about a specific image version/variant. 

They are aliases to the ID of your image which often look like this: f1477ec11d12. 

It's just a way of referring to your image. However the tag can also include your username on dockerhub for pushing to dockerhub or the address of a private repository



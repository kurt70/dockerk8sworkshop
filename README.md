# Docker
This part of the workshop will give a light introduction to containerization and the docker technology. 
 
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

### Interactive session
An interactive session, starting at the bash terminal, can be created for those images that have the shell installed
```dockerfile
docker run -it ubuntu bash
```

Notice that since we did not have the ubuntu image locally it did an implicit pull of that image for us. 
 
### Exercise 1.1 Build WebAppTest
Images are created from Dockerfiles, where steps for creating your own image is done on top of a base image. In this project we find a Dockerfile using two separate base images.      




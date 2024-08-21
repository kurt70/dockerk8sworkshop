#Prerq. installer Docker desktop

#Bli familiær med dockerfile
#Lære å mappe opp kataloger og porter
#Enkel administrasjon

#Hente og kjøre kontainere
docker pull nodered/node-red
docker run nodered/node-red -p 1880:1880
docker run -d -p 1880:1880 --name mynodered -v /path/to/local/dir:/data nodered/node-red
docker logs mynodered

#Gå rett inn i en kontainer med base image
docker run -it --rm --name myubuntu ubuntu bash

docker exec -it ubuntu --name myubuntu

skriv 'exit' for å gå ut|

http://localhost:1880

#nedlastede oci containere
docker images

#Kjørende kontainerprosesser
docker ps

#Rydde opp ubrukte kontainere
docker system prune

#fjerne containere
docker delete mynodered

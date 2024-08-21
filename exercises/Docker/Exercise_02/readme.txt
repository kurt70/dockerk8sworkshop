#Lage kontainere

#I onstage
docker build -t onestage-blazor-server .
docker run --rm -d -p 8080:5000 --name blazorapp1 onestage-blazor-server

#I multistage
docker build -t multistage-blazor-app .
docker run --rm -d -p 8081:80 --name blazorapp2 multistage-blazor-app

#Multiarch
docker buildx create --use
docker buildx inspect --bootstrap
docker buildx build --platform linux/amd64,linux/arm64 -t yourusername/yourimage:latest --push .

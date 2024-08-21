#Installer chocolatey pakkemanager
https://docs.chocolatey.org/en-us/choco/setup/

choco install minikube k9s kubectx kubens

brew install minikube k9s kubectx

# Start Minikube med 3 noder. NB! Det må være ca 60 gb ledig lokalt. 20gb for hvert node
minikube start --nodes 3

minikube image load nodered/node-red:latest
minikube image load busybox
minikube image load docker.elastic.co/elasticsearch/elasticsearch:7.10.1
minikube image load fluent/fluentd:v1.12-debian-1
minikube image load docker.elastic.co/kibana/kibana:7.10.1
minikube image load node:14

#Excercise 7 - 8 er ikke ferdige. Men vi kan se på de hvis det blir tid.
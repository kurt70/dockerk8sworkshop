#Installer chocolatey pakkemanager
https://docs.chocolatey.org/en-us/choco/setup/

choco install minikube k9s kubectx kubens

brew install minikube k9s kubectx

# Start Minikube med 3 noder og en profilnavn "multinode-demo"
minikube start --nodes 3 -p multinode-demo

minikube image load nodered/node-red:latest -p multinode-demo
minikube image load busybox -p multinode-demo
minikube image load docker.elastic.co/elasticsearch/elasticsearch:7.10.1 -p multinode-demo
minikube image load fluent/fluentd:v1.12-debian-1 -p multinode-demo
minikube image load docker.elastic.co/kibana/kibana:7.10.1 -p multinode-demo
minikube image load node:14 -p multinode-demo
minikube image load busybox -p multinode-demo
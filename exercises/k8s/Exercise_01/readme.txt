#Pods, Deployments, Replicasets, HPA

# Start Minikube med 3 noder og en profilnavn "multinode-demo"
minikube start --nodes 3 -p multinode-demo

kubectl apply -f pod.yaml
kubectl get pods
kubectl delete -f pod.yaml

kubectl port-forward pod/node-red 1880:1880
kubectl port-forward service/node-red 1880:1880

kubectl apply -f deployment.yaml
kubectl get pods
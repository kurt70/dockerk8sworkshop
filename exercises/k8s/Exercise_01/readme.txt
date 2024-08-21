#Pods, Deployments, Replicasets, HPA

kubectl apply -f pod.yaml
kubectl get pods

kubectl port-forward pod/node-red 1880:1880
#gå til localhost:1880
#avslutt port-forward

kubectl port-forward service/node-red 1880:1880
#gå til localhost:1880
kubectl delete -f pod.yaml
#avslutt port-forward

kubectl apply -f deployment.yaml
kubectl get pods
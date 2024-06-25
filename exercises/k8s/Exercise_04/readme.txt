#Deamonset
minikube node add

kubectl apply -f .\elasticsearch.yaml
kubectl apply -f .\kibana.yaml
kubectl apply -f .\fluentd.yaml

http://localhost:9200/


kubectl delete -f .\elasticsearch.yaml
kubectl delete -f .\kibana.yaml
kubectl delete -f .\fluentd.yaml
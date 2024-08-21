#Deamonset

kubectl apply -f .\elasticsearch.yaml
kubectl apply -f .\kibana.yaml
kubectl apply -f .\fluentd.yaml

kubectl port-forward svc/kibana 5601:5601

http://localhost:5601/


kubectl delete -f .\elasticsearch.yaml
kubectl delete -f .\kibana.yaml
kubectl delete -f .\fluentd.yaml
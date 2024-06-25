#Job & Cronjob

#Engangsjobb
kubectl apply -f simple-job.yaml

#Conjobb - kjører hvert sekunde
kubectl apply -f simple-cronjob.yaml

klubectl logs job/xxxxxxxxxxxx

# Stoppe Minikube-klusteret
minikube stop -p multinode-demo

# Slette Minikube-klusteret
minikube delete -p multinode-demo

# Rydde opp etter Minikube (slette alle Minikube-klynger)
minikube delete --all
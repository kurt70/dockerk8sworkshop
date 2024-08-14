#Job & Cronjob

#Engangsjobb
kubectl apply -f simple-job.yaml

#Conjobb - kjører hvert sekund
kubectl apply -f simple-cronjob.yaml

klubectl logs job/xxxxxxxxxxxx

# Stoppe Minikube-klusteret
minikube stop 

# Slette Minikube-klusteret
minikube delete

# Rydde opp etter Minikube (slette alle Minikube-klynger)
minikube delete --all
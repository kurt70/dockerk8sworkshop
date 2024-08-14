#Sette opp et komplett ci/cd miljø lokalt

#Installere Helm pakkemanager
brew install helm

#Installere gitea

helm repo add gitea-charts https://dl.gitea.io/charts/
helm repo update


helm install gitea gitea-charts/gitea --namespace gitea --create-namespace  --set postgresql.enabled=true --set postgresql.postgresqlPassword=mysecretpassword --set persistence.enabled=true --set persistence.size=5Gi --set persistence.existingClaim=gitea-pvc --set gitea.config.server.SSH_PORT=2222 --set gitea.admin.username=admin --set gitea.admin.password=adminpassword --set gitea.admin.email=admin@example.com --set replicaCount=1


helm install gitea gitea-charts/gitea --namespace gitea --create-namespace -f values.yaml

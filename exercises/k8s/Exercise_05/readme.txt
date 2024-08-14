#Ingress

minikube addons enable ingress

kubectl apply -f node-app.yaml

#På Linux/Mac
sudo nano /etc/hosts

#På Windows:
notepad C:\Windows\System32\drivers\etc\hosts

#Legg til nederst:
127.0.0.1   node-app.local

 kubectl port-forward --namespace  ingress-nginx service/ingress-nginx-controller 8080:80

#Sjekk i nettleser
http://node-app.local:8080
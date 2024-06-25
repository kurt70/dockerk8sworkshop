#Miljøvariabler og hemmeligheter

#Imperativ opprettelse
kubectl create secret generic node-red-secret --from-literal=username=admin --from-literal=password=hemmelig

#Declerativ opprettelse
#kubectl apply -f secret.yaml
kubectl apply -f configmap.yaml
kubectl apply -f node-red.yaml

#Oppsett av jupyter notbookserver med persistent lagring
kubectl apply -f jupyter.yaml

kubectl port-forward deploy/jupyter-notebook 8888:8888

#gå til 
http://localhost:8888


#Rydd opp
kubectl delete -f jupyter.yaml
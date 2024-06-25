#Private volumes, private volume claims, storageclasses

kubectl apply -f pv.yaml
kubectl apply -f pvc1.yaml
#kubectl apply -f pvc2.yaml #prebinding av volume

kubctl get pv -owide
kubctl get pvc -owide

kubectl describe pod/deploy/pv/pvc

Kubectl get storageclass
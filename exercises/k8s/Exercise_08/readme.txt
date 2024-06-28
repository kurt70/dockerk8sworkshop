#Helm, istio, sidecars, crds

#Installer Helm
choco install kubernetes-helm
brew install helm

#Legg til istio namespace
helm repo add istio https://istio-release.storage.googleapis.com/charts
helm repo update

#Installer istio base
helm install istio-base istio/base -n istio-system --create-namespace

#Installer Istio-discoverykomponenten:
helm install istiod istio/istiod -n istio-system

#Installer Istio-ingresskomponenten:
helm install istio-ingress istio/gateway -n istio-system

#Aktivere automatisk sidecar-injeksjon i default-namespace:
kubectl label namespace default istio-injection=enabled

#Opprette test kontainere
kubectl apply -f mtls-example.yaml

#Kontrollere resursene
kubectl get deployments
kubectl get services
kubectl get destinationrules.networking.istio.io
kubectl get peerauthentications.security.istio.io

#Gå inn i k9s og kjør shell i app1 eller app2
#Sjekk at du får svar på begge adressene

curl http://app1.default.svc.cluster.local
curl http://app2.default.svc.cluster.local

# Installere Prometheus & Grafana
helm repo add prometheus-community https://prometheus-community.github.io/helm-charts
helm repo add grafana https://grafana.github.io/helm-charts
helm repo update

helm install prometheus prometheus-community/prometheus -n istio-system

helm install grafana grafana/grafana -n istio-system --set adminPassword='hemmelig'

#Generer selvsignert cert secret
cd certs
#Følgende er allerede gjort
# Generer en privat nøkkel
#openssl genrsa -out tls.key 2048
# Generer en selvsignert sertifikat
#openssl req -new -x509 -key tls.key -out tls.crt -days 365 -subj "/CN=prometheus-adapter.custom-metrics.svc"

#Opprette secret
kubectl create secret tls prometheus-adapter-tls --cert=tls.crt --key=tls.key -n custom-metrics

#Opprett Prometheus adapter
kubectl apply -f prometheus-adapter.yaml

#Opprett ny hpa med metrics fra istio
kubectl apply -f new-hpa.yaml

#For å gå inn i prometheus dashboard
kubectl port-forward -n istio-system svc/prometheus-server 9090:80
http://localhost:9090

#Konfigurer grafana til å bruke istio som datakilde
kubectl port-forward -n istio-system svc/grafana 3000:80
http://localhost:3000

#Logg inn på Grafana: Åpne Grafana i nettleseren din (http://localhost:3000) og logg inn.
#Legg til Prometheus som datakilde:
#Gå til Configuration (tannhjul-ikonet) > Data Sources.
#Klikk på Add data source.
#Velg Prometheus.
#I URL-feltet, skriv inn http://prometheus-server.istio-system.svc.cluster.local.
#Klikk på Save & Test for å verifisere tilkoblingen.

#Grafana har ferdige dashboards for å visualisere Istio-metrikker. Her er trinnene for å importere et Istio-dashboard:

#Finn et ferdig dashboard:

#Gå til Grafana.com Dashboards og søk etter "Istio".
#For eksempel, dashboard 7635 er et populært valg.
#Importer dashboardet:

#Gå til Create (pluss-ikonet) > Import i Grafana.
#Skriv inn dashboard ID (for eksempel 7635) og klikk Load.
#Velg Prometheus-datakilden du opprettet tidligere.
#Klikk Import.
# Run web api in docker

clone repository and build and run image locally

```sh
git clone https://github.com/Revazashvili/k8s-deployment.git
cd k8s-deployment/csharp/
docker-compose up
```

or run image from docker hub

```sh
docker run revazashvili/k8s-api-example:1.0.0
```

<br/>

# Deploy c# web api on k8s

## Automated

```sh
cd k8s-deployment/csharp/kubernetes
chmod +x deploy.sh
./deploy.sh
```

or deploy manually

## Namespace

create namespace and resources for api

```sh
kubectl apply -f namespace.yaml
```

## CSharp

apply config map

```sh
kubectl apply -f ./charp/config.yaml
kubectl apply -f ./csharp/secret.yaml
kubectl apply -f ./csharp/service.yaml
kubectl apply -f ./csharp/deployment.yaml
```

## Postgres

apply deployment file

```sh
kubectl apply -f ./postgres/secret.yaml
kubectl apply -f ./postgres/service.yaml
kubectl apply -f ./postgres/deployment.yaml
```

## Display resources under namespace

```sh
kubectl get deploy -n csharp
```

<br/>

# Delete deployment

list deployments, you will see 'csharp-api-deployment'

```sh
kubectl get deploy -n csharp
```

delete deploy

```sh
kubectl delete deploy csharp-api-deployment -n csharp
```

# Delete Namespace

delete deploy

```sh
kubectl delete ns csharp
```

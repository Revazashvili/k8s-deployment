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
cd k8s-deployment/csharp/
chmod +x deploy.sh
./deploy.sh
```

or deploy manually

## Namespace

create namespace and resources for api

```sh
kubectl apply -f ./kubernetes/namespace.yaml
```

display namespaces

```sh
kubectl get namespace
```

## ConfigMap

apply config map

```sh
kubectl apply -f ./kubernetes/config.yaml
```

display config map

```sh
kubectl -n csharp get configMap
```

## Deployment

apply deployment file

```sh
kubectl apply -f ./kubernetes/deployment.yaml
```

display resources under namespace

```sh
kubectl get deploy -n csharp
```

```sh display running pods
kubectl -n csharp get pod
```

you can check running pod logs

```sh
kubectl -n csharp logs <POD_NAME>
```

## Service

apply service file

```sh
kubectl apply -f ./kubernetes/service.yaml
```

check service, external ip is localhost

```sh
kubectl -n csharp get svc
```

describe service, check that Endpoints is not empty, if empty pod can't take requests

```sh
kubectl -n csharp describe svc csharp-api-service
```

<br/>

# Stop deployment

list deployments, you will see 'csharp-api-deployment'

```sh
kubectl get deploy -n csharp
```

delete deploy

```sh
kubectl delete deploy csharp-api-deployment -n csharp
```

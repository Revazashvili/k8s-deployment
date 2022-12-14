# Run web api in docker

clone repository and build and run image locally

```sh
git clone https://github.com/Revazashvili/k8s-deployment.git
cd k8s-deployment/golang/
docker-compose up
```

or run image from docker hub

```sh
docker run revazashvili/k8s-go-api-example:1.0.0
```

<br/>

# Deploy c# web api on k8s

## Automated

```sh
cd k8s-deployment/golang/
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

## Deployment

apply deployment file

```sh
kubectl apply -f ./kubernetes/deployment.yaml
```

display resources under namespace

```sh
kubectl get deploy -n golang
```

```sh display running pods
kubectl -n golang get pod
```

you can check running pod logs

```sh
kubectl -n golang logs <POD_NAME>
```

## Service

apply service file

```sh
kubectl apply -f ./kubernetes/service.yaml
```

check service, external ip is localhost

```sh
kubectl -n golang get svc
```

describe service, check that Endpoints is not empty, if empty pod can't take requests

```sh
kubectl -n golang describe svc golang-api-service
```

<br/>

# Stop deployment

list deployments, you will see 'golang-api-deployment'

```sh
kubectl get deploy -n golang
```

delete deploy

```sh
kubectl delete deploy golang-api-deployment -n golang
```

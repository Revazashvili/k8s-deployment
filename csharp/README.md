## run web api
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


## deploy c# web api on k8s

# namespace

create namespace and resources for api
```sh
kubectl create namespace csharp
```

# deployment

apply deployment file
```sh
kubectl -n csharp apply -f ./kubernetes/deployment.yaml
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

# service

apply service file
```sh
kubectl -n csharp apply -f ./kubernetes/service.yaml
```

check service, external ip is localhost
```sh
kubectl -n csharp get svc
```

describe service, check that Endpoints is not empty, if empty pod can't take requests
```sh
kubectl -n csharp describe svc csharp-api-service
```

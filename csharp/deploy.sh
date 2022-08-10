#!/bin/bash

cecho(){
    RED="\033[0;31m"
    GREEN="\033[0;32m"  # <-- [0 means not bold
    YELLOW="\033[1;33m" # <-- [1 means bold
    CYAN="\033[1;36m"
    # ... Add more colors if you like

    NC="\033[0m" # No Color

    # printf "${(P)1}${2} ${NC}\n" # <-- zsh
    printf "${!1}${2} ${NC}\n" # <-- bash
}


# create namespace
cecho "GREEN" "create namespace"
kubectl apply -f ./kubernetes/namespace.yaml

# display namespace
cecho "GREEN" "display namespace"
kubectl get namespace

# config map
cecho "GREEN" "apply config map"
kubectl apply -f ./kubernetes/config.yaml

# deployment
cecho "GREEN" "apply deployment"
kubectl apply -f ./kubernetes/deployment.yaml

# display resources
cecho "GREEN" "display resources"
kubectl get deploy -n csharp

# display pods
cecho "GREEN" "display pods"
kubectl -n csharp get pod

# apply service file
cecho "GREEN" "apply service"
kubectl apply -f ./kubernetes/service.yaml

# check service
cecho "GREEN" "check service"
kubectl -n csharp get svc

# describe service
cecho "GREEN" "describe service"
kubectl -n csharp describe svc csharp-api-service
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
kubectl apply -f namespace.yaml

# csharp config map
cecho "GREEN" "apply csharp config map"
kubectl apply -f ./csharp/config.yaml

# csharp secret
cecho "GREEN" "apply csharp secret"
kubectl apply -f ./csharp/secret.yaml

# postgres secret
cecho "GREEN" "apply postgres secret"
kubectl apply -f ./postgres/secret.yaml


# apply csharp service file
cecho "GREEN" "apply csharp service"
kubectl apply -f ./csharp/service.yaml

# apply postgres service file
cecho "GREEN" "apply postgres service"
kubectl apply -f ./postgres/service.yaml

# csharp deployment
cecho "GREEN" "apply csharp deployment"
kubectl apply -f ./csharp/deployment.yaml

# postgres deployment
cecho "GREEN" "apply postgres deployment"
kubectl apply -f ./postgres/deployment.yaml

# display resources
cecho "GREEN" "display resources"
kubectl get deploy -n csharp

# display pods
cecho "GREEN" "display pods"
kubectl -n csharp get pod
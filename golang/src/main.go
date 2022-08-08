package main

import (
	"errors"
	"fmt"
	"io"
	"net/http"
	"os"
)

func getHello(w http.ResponseWriter, r *http.Request) {
	fmt.Printf("got /ping request\n")
	io.WriteString(w, "pong \n")
}

func main() {
	http.HandleFunc("/ping", getHello)

	err := http.ListenAndServe(":80", nil)

	if errors.Is(err, http.ErrServerClosed) {
		fmt.Printf("server closed\n")
	} else if err != nil {
		fmt.Printf("error starting server: %s\n", err)
		os.Exit(1)
	}
	fmt.Printf("api started")
}
FROM golang:1.19.0-alpine3.16

RUN mkdir /api/
WORKDIR /api/

COPY ./src/go.mod ./

RUN go mod tidy
RUN go mod download

COPY ./src/*.go ./

RUN go build main.go

CMD [ "./main" ]
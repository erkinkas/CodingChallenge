# CodingChallenge

Paymentsense coding challenge

## Setup

- Please download latest dotnet core (3+) -> https://dotnet.microsoft.com/download/dotnet-core

## Run backend

1. (optional) installing dev certificates for https (Windows and macOS only)

```
dotnet dev-certs https
dotnet dev-certs https --trust
```

2. run backend

```
cd ./paymentsense-coding-challenge-api/Paymentsense.Coding.Challenge.Api
dotnet restore
dotnet build
dotnet run
```

(optional) available profiles:

```
dotnet run --launch-profile "Development"
dotnet run --launch-profile "Production"
```

3. open http://localhost:5000/swagger

## Run frontend

1. run frontend

```
cd ./paymentsense-coding-challenge-website/
npm i
npm run build
npm run start-dev
```

(optional) available builds:

```
npm run build
npm run build-prod
```

2. open http://localhost:4200/

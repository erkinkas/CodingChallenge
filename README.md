# CodingChallenge
Paymentsense coding challenge

## Setup
* Please download latest dotnet core (3+) -> https://dotnet.microsoft.com/download/dotnet-core

## run backend

1. [optional] installing dev certificates for https (Windows and macOS only)
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

3. open http://localhost:5000/swagger

## run frontend

1. run frontend
```
cd ./paymentsense-coding-challenge-website/
npm i
npm run build
npm run start-dev
```
2. open http://localhost:4200/

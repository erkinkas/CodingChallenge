# CodingChallenge
Paymentsense coding challenge

## Setup
* Please download latest dotnet core (3+) -> https://dotnet.microsoft.com/download/dotnet-core



## Installing dev certificates for https (Windows and macOS only)
```
dotnet dev-certs https
dotnet dev-certs https --trust
```

## run back-end

1.
```
cd ./paymentsense-coding-challenge-api/Paymentsense.Coding.Challenge.Api
dotnet restore
dotnet build
dotnet run
```

2. open http://localhost:5000/swagger

## run front-end
1.
```
cd ./paymentsense-coding-challenge-website/
npm i
npm run build
npm run start-dev
```
2. open http://localhost:4200/

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
EXPOSE 80
EXPOSE 443

WORKDIR /src
COPY . .
WORKDIR /src/WSServices.WebApi
RUN dotnet restore
RUN dotnet publish -c Release -o out	

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
COPY --from=build-env /src/WSServices.WebApi/out ./
ENTRYPOINT ["dotnet", "WSServices.WebApi.dll"]

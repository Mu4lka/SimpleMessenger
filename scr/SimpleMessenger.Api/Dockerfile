#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["scr/SimpleMessenger.Api/SimpleMessenger.Api.csproj", "scr/SimpleMessenger.Api/"]
COPY ["scr/Infrastucture/Infrastucture.csproj", "scr/Infrastucture/"]
COPY ["scr/SimpleMessenger.Contracts/SimpleMessenger.Contracts.csproj", "scr/SimpleMessenger.Contracts/"]
COPY ["scr/SimpleMessenger.Domain/SimpleMessenger.Domain.csproj", "scr/SimpleMessenger.Domain/"]
COPY ["scr/SimpleMessenger.Application/SimpleMessenger.Application.csproj", "scr/SimpleMessenger.Application/"]
RUN dotnet restore "./scr/SimpleMessenger.Api/SimpleMessenger.Api.csproj"
COPY . .
WORKDIR "/src/scr/SimpleMessenger.Api"
RUN dotnet build "./SimpleMessenger.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SimpleMessenger.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleMessenger.Api.dll"]
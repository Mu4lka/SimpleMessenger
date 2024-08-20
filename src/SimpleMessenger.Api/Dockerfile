FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SimpleMessenger.Api/SimpleMessenger.Api.csproj", "src/SimpleMessenger.Api/"]
COPY ["src/Infrastucture/Infrastucture.csproj", "src/Infrastucture/"]
COPY ["src/SimpleMessenger.Contracts/SimpleMessenger.Contracts.csproj", "src/SimpleMessenger.Contracts/"]
COPY ["src/SimpleMessenger.Domain/SimpleMessenger.Domain.csproj", "src/SimpleMessenger.Domain/"]
COPY ["src/SimpleMessenger.Application/SimpleMessenger.Application.csproj", "src/SimpleMessenger.Application/"]
RUN dotnet restore "./src/SimpleMessenger.Api/SimpleMessenger.Api.csproj"
COPY . .
WORKDIR "/src/src/SimpleMessenger.Api"
RUN dotnet build "./SimpleMessenger.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SimpleMessenger.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleMessenger.Api.dll"]
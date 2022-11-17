FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BankingClientBackend.DataAccess.WebserviceProxy/BankingClientBackend.DataAccess.WebserviceProxy.csproj", "BankingClientBackend.DataAccess.WebserviceProxy/"]
RUN dotnet restore "BankingClientBackend.DataAccess.WebserviceProxy/BankingClientBackend.DataAccess.WebserviceProxy.csproj"
COPY . .
WORKDIR "/src/BankingClientBackend.DataAccess.WebserviceProxy"
RUN dotnet build "BankingClientBackend.DataAccess.WebserviceProxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankingClientBackend.DataAccess.WebserviceProxy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankingClientBackend.DataAccess.WebserviceProxy.dll"]

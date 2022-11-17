FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BankingClientBackend/BankingClientBackend.csproj", "BankingClientBackend/"]
RUN dotnet restore "BankingClientBackend/BankingClientBackend.csproj"
COPY . .
WORKDIR "/src/BankingClientBackend"
RUN dotnet build "BankingClientBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankingClientBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankingClientBackend.dll"]

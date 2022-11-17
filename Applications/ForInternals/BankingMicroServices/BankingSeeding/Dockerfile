FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BankingSeeding/BankingSeeding.csproj", "BankingSeeding/"]
RUN dotnet restore "BankingSeeding/BankingSeeding.csproj"
COPY . .
WORKDIR "/src/BankingSeeding"
RUN dotnet build "BankingSeeding.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankingSeeding.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankingSeeding.dll"]

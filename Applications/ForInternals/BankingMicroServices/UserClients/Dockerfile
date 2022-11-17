FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserClients/UserClients.csproj", "UserClients/"]
RUN dotnet restore "UserClients/UserClients.csproj"
COPY . .
WORKDIR "/src/UserClients"
RUN dotnet build "UserClients.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserClients.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserClients.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InternalUsers/InternalUsers.csproj", "InternalUsers/"]
RUN dotnet restore "InternalUsers/InternalUsers.csproj"
COPY . .
WORKDIR "/src/InternalUsers"
RUN dotnet build "InternalUsers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InternalUsers.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InternalUsers.dll"]

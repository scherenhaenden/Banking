FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SmallConsoleView/SmallConsoleView.csproj", "SmallConsoleView/"]
RUN dotnet restore "SmallConsoleView/SmallConsoleView.csproj"
COPY . .
WORKDIR "/src/SmallConsoleView"
RUN dotnet build "SmallConsoleView.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmallConsoleView.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmallConsoleView.dll"]

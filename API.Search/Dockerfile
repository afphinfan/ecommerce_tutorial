FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["API.Search/API.Search.csproj", "API.Search/"]
RUN dotnet restore "API.Search/API.Search.csproj"
COPY . .
WORKDIR "/src/API.Search"
RUN dotnet build "API.Search.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.Search.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Search.dll"]
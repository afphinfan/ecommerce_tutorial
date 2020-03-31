FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["API.Orders/API.Orders.csproj", "API.Orders/"]
RUN dotnet restore "API.Orders/API.Orders.csproj"
COPY . .
WORKDIR "/src/API.Orders"
RUN dotnet build "API.Orders.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.Orders.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Orders.dll"]
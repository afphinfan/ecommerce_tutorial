FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["API.Products/API.Products.csproj", "API.Products/"]
RUN dotnet restore "API.Products/API.Products.csproj"
COPY . .
WORKDIR "/src/API.Products"
RUN dotnet build "API.Products.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.Products.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Products.dll"]
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/CatalogContext/CatalogContext.Api/CatalogContext.Api.csproj", "src/CatalogContext/CatalogContext.Api/"]
COPY ["src/CatalogContext/CatalogContext.Application/CatalogContext.Application.csproj", "src/CatalogContext/CatalogContext.Application/"]
COPY ["src/CatalogContext/CatalogContext.Domain/CatalogContext.Domain.csproj", "src/CatalogContext/CatalogContext.Domain/"]
COPY ["src/CatalogContext/CatalogContext.Infrastructure/CatalogContext.Infrastructure.csproj", "src/CatalogContext/CatalogContext.Infrastructure/"]

RUN dotnet restore "src/CatalogContext/CatalogContext.Api/CatalogContext.Api.csproj"

COPY . .

WORKDIR "/src/src/CatalogContext/CatalogContext.Api"
RUN dotnet publish "CatalogContext.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CatalogContext.Api.dll"]

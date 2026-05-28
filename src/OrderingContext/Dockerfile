FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/OrderingContext/OrderingContext.Api/OrderingContext.Api.csproj", "src/OrderingContext/OrderingContext.Api/"]
COPY ["src/OrderingContext/OrderingContext.Application/OrderingContext.Application.csproj", "src/OrderingContext/OrderingContext.Application/"]
COPY ["src/OrderingContext/OrderingContext.Domain/OrderingContext.Domain.csproj", "src/OrderingContext/OrderingContext.Domain/"]
COPY ["src/OrderingContext/OrderingContext.Infrastructure/OrderingContext.Infrastructure.csproj", "src/OrderingContext/OrderingContext.Infrastructure/"]

RUN dotnet restore "src/OrderingContext/OrderingContext.Api/OrderingContext.Api.csproj"

COPY . .

WORKDIR "/src/src/OrderingContext/OrderingContext.Api"
RUN dotnet publish "OrderingContext.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "OrderingContext.Api.dll"]

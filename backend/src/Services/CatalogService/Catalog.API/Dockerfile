#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/CatalogService/Catalog.API/Catalog.API.csproj", "src/Services/CatalogService/Catalog.API/"]
COPY ["src/Services/CatalogService/Catalog.Application/Catalog.Application.csproj", "src/Services/CatalogService/Catalog.Application/"]
COPY ["src/Services/CatalogService/Catalog.Core/Catalog.Core.csproj", "src/Services/CatalogService/Catalog.Core/"]
COPY ["src/Services/CatalogService/Catalog.Infrastructure/Catalog.Infrastructure.csproj", "src/Services/CatalogService/Catalog.Infrastructure/"]
RUN dotnet restore "src/Services/CatalogService/Catalog.API/Catalog.API.csproj"
COPY . .
WORKDIR "/src/src/Services/CatalogService/Catalog.API"
RUN dotnet build "Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.API.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Catalog.API.dll"]

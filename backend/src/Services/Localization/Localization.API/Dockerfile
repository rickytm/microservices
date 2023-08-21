#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/GatewayService/GatewayService.csproj", "src/Services/GatewayService/"]
COPY ["src/Services/Localization/Localization.API/Localization.API.csproj", "src/Services/Localization/Localization.API/"]
COPY ["src/Services/Localization/Localization.Application/Localization.Application.csproj", "src/Services/Localization/Localization.Application/"]
COPY ["src/Services/Localization/Localization.Core/Localization.Core.csproj", "src/Services/Localization/Localization.Core/"]
COPY ["src/Services/Localization/Localization.Infrastructure/Localization.Infrastructure.csproj", "src/Services/Localization/Localization.Infrastructure/"]

RUN dotnet restore "src/Services/Localization/Localization.API/Localization.API.csproj"

COPY . .
WORKDIR "/src/src/Services/Localization/Localization.API"
RUN dotnet build "Localization.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Localization.API.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Localization.API.dll"]

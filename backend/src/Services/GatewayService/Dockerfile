#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/GatewayService/GatewayService.csproj", "src/Services/GatewayService/"]
COPY ["src/Services/Localization/Localization.API/Localization.API.csproj", "src/Services/Localization/Localization.API/"]
RUN dotnet restore "src/Services/GatewayService/GatewayService.csproj"
COPY . .
WORKDIR "/src/src/Services/GatewayService"
RUN dotnet build "GatewayService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GatewayService.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "GatewayService.dll"]

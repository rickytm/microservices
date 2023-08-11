FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/IdentityService/IdentityService.Admin.Api/IdentityService.Admin.Api.csproj", "src/Services/IdentityService/IdentityService.Admin.Api/"]
COPY ["src/Services/IdentityService/IdentityService.Admin.EntityFramework.Shared/IdentityService.Admin.EntityFramework.Shared.csproj", "src/Services/IdentityService/IdentityService.Admin.EntityFramework.Shared/"]
COPY ["src/Services/IdentityService/IdentityService.Shared/IdentityService.Shared.csproj", "src/Services/IdentityService/IdentityService.Shared/"]
COPY ["src/Services/IdentityService/IdentityService.Admin.EntityFramework.PostgreSQL/IdentityService.Admin.EntityFramework.PostgreSQL.csproj", "src/Services/IdentityService/IdentityService.Admin.EntityFramework.PostgreSQL/"]
RUN dotnet restore "src/Services/IdentityService/IdentityService.Admin.Api/IdentityService.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/IdentityService/IdentityService.Admin.Api"
RUN dotnet build "IdentityService.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityService.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "IdentityService.Admin.Api.dll"]
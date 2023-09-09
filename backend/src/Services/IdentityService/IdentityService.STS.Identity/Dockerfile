FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/IdentityService/IdentityService.STS.Identity/IdentityService.STS.Identity.csproj", "src/Services/IdentityService/IdentityService.STS.Identity/"]
COPY ["src/Services/IdentityService/IdentityService.Admin.EntityFramework.Shared/IdentityService.Admin.EntityFramework.Shared.csproj", "src/Services/IdentityService/IdentityService.Admin.EntityFramework.Shared/"]
COPY ["src/Services/IdentityService/IdentityService.Shared/IdentityService.Shared.csproj", "src/Services/IdentityService/IdentityService.Shared/"]
RUN dotnet restore "src/Services/IdentityService/IdentityService.STS.Identity/IdentityService.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/Services/IdentityService/IdentityService.STS.Identity"
RUN dotnet build "IdentityService.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityService.STS.Identity.csproj" -c Release -o /app/publish \	
	              --runtime linux-musl-x64 \ 
                  --self-contained true \
#                  /p:PublishTrimmed=true \
                  /p:PublishReadyToRun=true \
                  /p:PublishSingleFile=true 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "IdentityService.STS.Identity.dll"]
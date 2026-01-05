# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY RobotCar.Site/RobotCar.Site.csproj RobotCar.Site/

RUN dotnet restore RobotCar.Site/RobotCar.Site.csproj

COPY RobotCar.Site/ RobotCar.Site/

RUN dotnet publish RobotCar.Site/RobotCar.Site.csproj \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false \
    --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "RobotCar.Site.dll"]

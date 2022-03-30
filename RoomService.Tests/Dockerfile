ARG BUILD_TAG=3.0
ARG BASE_TAG=3.0
FROM mcr.microsoft.com/dotnet/core/runtime:${BASE_TAG} AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:${BASE_TAG} AS build
WORKDIR /src
COPY ["RoomService.Tests/RoomService.Tests.csproj", "RoomService.Tests/"]
COPY ["RoomService.WebAPI/RoomService.WebAPI.csproj", "RoomService.WebAPI/"]
RUN dotnet restore "RoomService.Tests/RoomService.Tests.csproj"
COPY . .
WORKDIR "/src/RoomService.Tests"
RUN dotnet build "RoomService.Tests.csproj" -c Release -o /app/build
ENTRYPOINT ["dotnet", "test"]

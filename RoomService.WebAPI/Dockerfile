ARG BUILD_TAG=3.0
ARG BASE_TAG=3.0
FROM mcr.microsoft.com/dotnet/core/aspnet:${BASE_TAG} AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:${BASE_TAG} AS build
WORKDIR /src
COPY ["RoomService.WebAPI/RoomService.WebAPI.csproj", "RoomService.WebAPI/"]
RUN dotnet restore "RoomService.WebAPI/RoomService.WebAPI.csproj"
COPY . .
WORKDIR "/src/RoomService.WebAPI"
RUN dotnet build "RoomService.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RoomService.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoomService.WebAPI.dll"]

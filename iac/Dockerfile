FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src
COPY ["./src/TvMaze.Api.Host/TvMaze.Api.Host.csproj", "src/TvMaze.Api.Host/"]
COPY ["./src/TvMaze.Auth/TvMaze.Auth.csproj", "src/TvMaze.Auth/"]
COPY ["./src/TvMaze.Api/TvMaze.Api.csproj", "src/TvMaze.Api/"]
COPY ["./src/TvMaze.Application/TvMaze.Application.csproj", "src/TvMaze.Application/"]
COPY ["./src/TvMaze.Client.Http/TvMaze.Client.Http.csproj", "src/TvMaze.Client.Http/"]
COPY ["./src/TvMaze.Contracts/TvMaze.Contracts.csproj", "src/TvMaze.Contracts/"]
COPY ["./src/TvMaze.Data/TvMaze.Data.csproj", "src/TvMaze.Data/"]
COPY ["./src/TvMaze.Domain/TvMaze.Domain.csproj", "src/TvMaze.Domain/"]

RUN dotnet restore "./src/TvMaze.Api.Host/./TvMaze.Api.Host.csproj"
COPY . .

WORKDIR "/src/src/TvMaze.Api.Host"
RUN dotnet build "./TvMaze.Api.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "./TvMaze.Api.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TvMaze.Api.Host.dll"]
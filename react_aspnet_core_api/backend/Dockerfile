FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# EXPOSE 80

# Copy everything
COPY . ./

COPY backend/backend.api/appsettings.Docker.json backend/backend.api/appsettings.Docker.json

# Restore as distinct layers
RUN dotnet restore backend/backend.api

# Build and publish a release
RUN dotnet publish backend/backend.api -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "backend.api.dll"]
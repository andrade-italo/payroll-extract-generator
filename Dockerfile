# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the project file and restore dependencies
COPY . ./
RUN dotnet restore

# Build and publish a release
WORKDIR /app/src/Api
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
COPY --from=build-env /app/src/Api/out .

# Run the application when the container starts
ENTRYPOINT ["dotnet", "PayrollExtractGenerator.Api.dll"]
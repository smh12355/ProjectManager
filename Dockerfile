# Use the official .NET 6 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory in the container
WORKDIR /src

# Copy the csproj files and restore dependencies
COPY ./src/ProjectManager/ProjectManager.csproj ./ProjectManager/
COPY ./src/ProjectManager.Application/ProjectManager.Application.csproj ./ProjectManager.Application/
COPY ./src/ProjectManager.Domain/ProjectManager.Domain.csproj ./ProjectManager.Domain/
COPY ./src/ProjectManager.Infrastructure/ProjectManager.Infrastructure.csproj ./ProjectManager.Infrastructure/

RUN dotnet restore ./ProjectManager/ProjectManager.csproj

# Copy the rest of the project files
COPY ./src .

# Build the application
RUN dotnet publish ./ProjectManager/ProjectManager.csproj -c Release -o /app/publish

# Use the official .NET 6 runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the published files from the build image
COPY --from=build /app/publish .

# Expose port 80 for the application
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "ProjectManager.dll"]
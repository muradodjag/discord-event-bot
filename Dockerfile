# Set the base image for build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

# Copy .csproj files
COPY ["src/Bot/Bot.csproj", "./Bot/"]

# Restore the project dependencies
RUN dotnet restore "./Bot/Bot.csproj"

# Copy all the files from the host to the Docker image
COPY . .

# Change the working directory to your main project
WORKDIR "/src/Bot"

# Build the project
RUN dotnet build "Bot.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "Bot.csproj" -c Release -o /app/publish

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base

WORKDIR /app
EXPOSE 5050

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bot.dll"]

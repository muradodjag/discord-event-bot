# Use the official .NET 7.0 SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory
WORKDIR /src

# Copy the project file and restore the associated NuGet packages
COPY ["src/Bot/Bot.csproj", "Bot/"]
RUN dotnet restore "Bot/Bot.csproj"

# Copy the rest of the source code
COPY . .

# Change the working directory
WORKDIR "/src/Bot"

# Build the application
RUN dotnet build "Bot.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Bot.csproj" -c Release -o /app/publish

# Use the official .NET 7.0 runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final

# Set the working directory
WORKDIR /app

# Copy the published application from the publish environment
COPY --from=publish /app/publish .

# Set the environment variable for ASP.NET Core to use port 5050
ENV ASPNETCORE_URLS=http://+:5050

# Expose port 5050
EXPOSE 5050

# Set the entry point for the container
ENTRYPOINT ["dotnet", "Bot.dll"]

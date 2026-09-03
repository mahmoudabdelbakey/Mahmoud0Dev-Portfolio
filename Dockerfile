# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["MahmoudDev.csproj", "./"]
RUN dotnet restore "./MahmoudDev.csproj"

# Copy full source and build
COPY . .
RUN dotnet publish "./MahmoudDev.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Render exposes and injects PORT (default 8080)
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "MahmoudDev.dll"]

# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Cache dependency restoration layer
COPY ["MahmoudDev.csproj", "./"]
RUN dotnet restore "MahmoudDev.csproj"

# Copy source and publish release artifact
COPY . .
RUN dotnet publish "MahmoudDev.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose port for Render
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "MahmoudDev.dll"]


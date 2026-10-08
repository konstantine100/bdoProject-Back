FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

# Copy csproj files first for Docker cache
COPY ["bdoProject.Api/bdoProject.Api.csproj", "bdoProject.Api/"]
COPY ["bdoProject.Application/bdoProject.Application.csproj", "bdoProject.Application/"]
COPY ["bdoProject.Infrastructure/bdoProject.Infrastructure.csproj", "bdoProject.Infrastructure/"]
COPY ["bdoProject.Domain/bdoProject.Domain.csproj", "bdoProject.Domain/"]

# Restore dependencies
RUN dotnet restore "bdoProject.Api/bdoProject.Api.csproj"

# Copy full source
COPY . .

# Publish application
WORKDIR /source/bdoProject.Api
RUN dotnet publish "bdoProject.Api.csproj" -c Release --self-contained false -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Native dependencies (only if your project needs them)
RUN apt-get update && apt-get install -y \
    libgdiplus \
    libopencv-dev \
    libfreetype6 \
    && rm -rf /var/lib/apt/lists/*

# Copy published files
COPY --from=build /app/publish .

# Render port
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "bdoProject.Api.dll"]

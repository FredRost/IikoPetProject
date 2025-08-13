# 1) Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем sln и csproj для быстрой реставрации
COPY IikoPetProject.sln ./
COPY src/IikoPetProject.Domain/IikoPetProject.Domain.csproj ./src/IikoPetProject.Domain/
COPY src/IikoPetProject.Application/IikoPetProject.Application.csproj ./src/IikoPetProject.Application/
COPY src/IikoPetProject.Infrastructure/IikoPetProject.Infrastructure.csproj ./src/IikoPetProject.Infrastructure/
COPY src/IikoPetProject.Api/IikoPetProject.Api.csproj ./src/IikoPetProject.Api/

# Restore
RUN dotnet restore ./src/IikoPetProject.Api/IikoPetProject.Api.csproj

# Копируем исходники
COPY src/ ./src/

# Publish
RUN dotnet publish ./src/IikoPetProject.Api/IikoPetProject.Api.csproj -c Release -o /app/publish

# 2) Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
COPY --from=build /app/publish ./
EXPOSE 80
ENTRYPOINT ["dotnet", "IikoPetProject.Api.dll"]

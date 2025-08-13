FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY IikoPetProject.sln ./
COPY src/IikoPetProject.Web/IikoPetProject.Web.csproj ./src/IikoPetProject.Web/
RUN dotnet restore ./src/IikoPetProject.Web/IikoPetProject.Web.csproj
COPY src/ ./src/
RUN dotnet publish ./src/IikoPetProject.Web/IikoPetProject.Web.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
COPY --from=build /app/publish ./
EXPOSE 80
ENTRYPOINT ["dotnet", "IikoPetProject.Web.dll"]

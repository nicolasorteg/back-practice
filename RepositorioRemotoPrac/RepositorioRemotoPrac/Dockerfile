# build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# copiar csproj y restaurar dependencias
COPY *.csproj .
RUN dotnet restore

# copiar el resto del código y publicar
COPY . .
RUN dotnet publish -c Release -o /app/publish --no-restore

# runtime
FROM mcr.microsoft.com/dotnet/runtime:10.0 AS runtime
WORKDIR /app

# user no-root
USER $APP_UID

# copiar solo lo publicado
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "RepositorioRemotoPrac.dll"]
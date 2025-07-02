# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el archivo .csproj y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del código y compilar
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Puerto de escucha del contenedor
EXPOSE 80

# Comando de inicio
ENTRYPOINT ["dotnet", "EmprendeLocal.dll"]

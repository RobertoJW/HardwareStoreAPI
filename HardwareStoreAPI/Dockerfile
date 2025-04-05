# Usa la imagen oficial de .NET para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Usa la imagen oficial de .NET SDK para compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia el archivo de la API y restaura los paquetes
COPY ["HardwareStoreAPI.csproj", "./"]
RUN dotnet restore "HardwareStoreAPI.csproj"

# Copia el resto del código y compila
COPY . .
RUN dotnet publish "HardwareStoreAPI.csproj" -c Release -o /app/publish

# Usa la imagen base para ejecutar la API
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "HardwareStoreAPI.dll"]

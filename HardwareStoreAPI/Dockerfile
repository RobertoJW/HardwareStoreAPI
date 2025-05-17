# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos csproj y restauramos paquetes
COPY HardwareStoreAPI.csproj ./
RUN dotnet restore HardwareStoreAPI.csproj

# Copiamos el resto y publicamos en Release
COPY . ./
RUN dotnet publish HardwareStoreAPI.csproj -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Instalar dependencias necesarias para MySQL y Cloud SQL socket
RUN apt-get update && apt-get install -y \
    libmysqlclient-dev \
    libssl-dev \
    ca-certificates \
    && rm -rf /var/lib/apt/lists/*

# Puerto que App Engine asigna en la variable PORT
ENV ASPNETCORE_URLS=http://+:${PORT}

# Copiamos los artefactos de la etapa 'build'
COPY --from=build /app/publish ./

# Punto de entrada
ENTRYPOINT ["dotnet", "HardwareStoreAPI.dll"]


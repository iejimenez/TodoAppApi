# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar los archivos de proyecto
COPY ["TodoApp.Api/TodoApp.Api.csproj", "TodoApp.Api/"]
COPY ["TodoApp.Application/TodoApp.Application.csproj", "TodoApp.Application/"]
COPY ["TodoApp.Domain/TodoApp.Domain.csproj", "TodoApp.Domain/"]
COPY ["TodoApi.Infrastructure/TodoApi.Infrastructure.csproj", "TodoApi.Infrastructure/"]

# Restaurar dependencias
RUN dotnet restore "TodoApp.Api/TodoApp.Api.csproj"

# Copiar el resto del código
COPY . .

# Publicar la aplicación
WORKDIR "/src/TodoApp.Api"
RUN dotnet publish "TodoApp.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copiar los archivos publicados
COPY --from=build /app/publish .

# Exponer el puerto 8080 (requerido por Cloud Run)
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "TodoApp.Api.dll"] 
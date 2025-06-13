# TodoApp API

API REST para gestión de tareas desarrollada en .NET Core.

## Requisitos Previos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [PostgreSQL](https://www.postgresql.org/download/) (versión 12 o superior)
- [Visual Studio 2022](https://visualstudio.microsoft.com/es/) o [Visual Studio Code](https://code.visualstudio.com/)

## Configuración de la Base de Datos

1. Instala PostgreSQL si aún no lo tienes instalado
2. Crea una base de datos llamada `TodoAppApi`
3. Crea un usuario con los siguientes datos:
   - Usuario: `TodoAppUser`
   - Contraseña: `Todoapp123*`

O Simplemente modifica la cadena de coneccion en archivo appsettings.json

    Server=tuserver;DataBase=tubdname;Port=tupuerto;User Id=tuusuario;Password=tupassword


## Pasos para Ejecutar la API

1. Clona el repositorio:
```bash
git clone https://github.com/iejimenez/TodoAppApi.git
cd TodoAppApi
```

2. Restaura los paquetes NuGet:

Desde la línea de comandos:
```bash
dotnet restore
```

Desde la Consola de Administración de Paquetes de NuGet (en Visual Studio):
```powershell
Update-Package -reinstall
```

3. Aplica las migraciones de la base de datos:

Desde la línea de comandos:
```bash
cd TodoApi.Infrastructure
dotnet ef database update
cd ..
```

Desde la Consola de Administración de Paquetes de NuGet (en Visual Studio):
```powershell
Update-Database -Project TodoApi.Infrastructure
```

4. Ejecuta la API:

Desde la línea de comandos:
```bash
cd TodoApp.Api
dotnet run
```

Desde Visual Studio:
- Presiona F5 o
- Haz clic en el botón "Iniciar" o
- Usa el menú Debug > Start Debugging

La API estará disponible en:
- URL: `https://localhost:7067`
- Swagger UI: `https://localhost:7067/swagger`

## Estructura del Proyecto

- `TodoApp.Api`: Capa de presentación y controladores
- `TodoApp.Application`: Lógica de negocio y servicios
- `TodoApp.Domain`: Entidades y reglas de dominio
- `TodoApi.Infrastructure`: Implementación de repositorios y acceso a datos

## Endpoints Disponibles

- `GET /api/TodoTask`: Obtener todas las tareas
- `GET /api/TodoTask/{id}`: Obtener una tarea específica
- `POST /api/TodoTask`: Crear una nueva tarea
- `PUT /api/TodoTask/{id}`: Actualizar una tarea existente
- `DELETE /api/TodoTask/{id}`: Eliminar una tarea
- `PATCH /api/TodoTask/{id}/toggle`: Cambiar el estado de una tarea

## Validaciones

La API incluye validaciones automáticas para:
- Título (requerido, máximo 200 caracteres)
- Descripción (requerida, máximo 1000 caracteres)
- Estado (debe ser "Pendiente" o "Completada")
- Fecha de expiración (debe ser posterior a la fecha actual)

## Manejo de Errores

La API incluye un middleware global para el manejo de excepciones que devuelve respuestas de error en formato JSON con:
- Código de estado HTTP
- Mensaje de error
- Detalles del error (en desarrollo)
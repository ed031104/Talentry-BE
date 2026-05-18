# Talentry Business Core

Este repositorio contiene dos aplicaciones principales:

- `Analysis.Worker`: servicio en segundo plano que debe ejecutarse primero.
- `TalentryBussinesCore`: API principal que debe ejecutarse después de levantar el worker.

## Requisitos

- .NET SDK 9.0
- Acceso a los archivos de configuración de cada proyecto

## Orden de ejecución

1. Inicia primero el worker service `Analysis.Worker`.
2. Cuando el worker esté ejecutándose, inicia la API `TalentryBussinesCore`.

Este orden es importante porque el API depende del servicio en segundo plano para que el sistema funcione de forma completa.

## Cómo ejecutar la solución

### Opción 1: desde la terminal

Abre dos terminales y ejecuta cada proyecto por separado:

```bash
dotnet run --project Analysis.Worker/Analysis.Worker.csproj
```

Después, en una segunda terminal:

```bash
dotnet run --project TalentryBussinesCore/TalentryBussinesCore.csproj
```

### Opción 2: desde Visual Studio / Rider / VS Code

- Ejecuta primero el proyecto `Analysis.Worker`.
- Luego ejecuta el proyecto `TalentryBussinesCore`.
- Si tu IDE permite múltiples perfiles de inicio, mantén ambos procesos activos al mismo tiempo.

## Configuración

Cada proyecto tiene su propio archivo de configuración:

- `Analysis.Worker/appsettings.json`
- `Analysis.Worker/appsettings.Development.json`
- `TalentryBussinesCore/appsettings.json`
- `TalentryBussinesCore/appsettings.Development.json`

### Worker

El worker usa `DOTNET_ENVIRONMENT=Development` desde su `launchSettings.json`.

Archivo principal de configuración:

- `Analysis.Worker/appsettings.json`

Archivo de desarrollo:

- `Analysis.Worker/appsettings.Development.json`

### API

El API usa `ASPNETCORE_ENVIRONMENT=Development` desde su `launchSettings.json`.

En desarrollo, el API expone los puertos configurados en `launchSettings.json`:

- HTTP: `http://localhost:5248`
- HTTPS: `https://localhost:7072`

La documentación OpenAPI queda disponible solo en entorno de desarrollo.

## Archivos relevantes

- [Solution](Talentry.sln)
- [Worker Program](Analysis.Worker/Program.cs)
- [API Program](TalentryBussinesCore/Program.cs)
- [Worker launch settings](Analysis.Worker/Properties/launchSettings.json)
- [API launch settings](TalentryBussinesCore/Properties/launchSettings.json)

## Notas

- El proyecto está dividido en capas: `Domain`, `Application` e `Infraestructure`.
- Si agregas nuevas configuraciones, colócalas en el `appsettings` correspondiente a cada proyecto.
- Si necesitas ejecutar el API en otro entorno, ajusta `ASPNETCORE_ENVIRONMENT` y las claves del `appsettings` según corresponda.
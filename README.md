# RaffleApp — Sorteos para la comunidad DevTalles

Backend de **CodeQuest #1**: una aplicación de sorteos para la comunidad de Discord de
DevTalles. Panel administrativo para gestionar sorteos, autenticación vía Discord OAuth2,
y selección de ganador con verificación de pertenencia al servidor.

Este repositorio contiene **únicamente el backend**. El frontend (React) vive en un
repositorio aparte.

## Stack

- **.NET 10** / ASP.NET Core Web API
- **PostgreSQL 16** + **Redis 7** (vía Docker Compose)
- **Entity Framework Core** (Code First) + **ASP.NET Core Identity**
- **Discord OAuth2** + JWT propio (sin login local)
- SignalR (notificaciones en tiempo real), Scalar (documentación OpenAPI), Serilog,
  xUnit + Moq + Testcontainers

## Estructura del proyecto (Screaming Architecture)

Las carpetas de primer nivel son features del dominio, no capas técnicas:

```
RaffleApp.Api/
├── Auth/                # Discord OAuth2, JWT propio, refresh tokens, ApplicationUser
├── Raffles/              # CRUD de sorteos
├── Participations/        # Unirse a un sorteo, anti-bots
├── Winners/               # Selección de ganador, historial, re-sorteo
├── Notifications/         # SignalR
└── Common/                # AuditableEntity, AppDbContext, interceptors, servicios
                            # compartidos — nada específico de una sola feature
```

Cada feature repite el mismo patrón interno: `Entities/`, `Configurations/`, `DTOs/`,
`Validators/`, `Mappers/`, `Repositories/`, `Services/`, `Controllers/` (solo las
carpetas que esa feature necesita).

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Docker + Docker Compose
- `dotnet-ef` (se instala como tool local, ver más abajo)

## Cómo levantar el entorno local

1. **Clonar el repo** y pararse en la carpeta del proyecto (`RaffleApp.Api/`).

2. **Copiar el archivo de variables de entorno:**

   ```bash
   cp .env.example .env
   ```

   Completar `.env` con valores propios (usuario/contraseña de PostgreSQL, nombre de la
   base). Este archivo **no se versiona**.

3. **Levantar PostgreSQL y Redis:**

   ```bash
   docker compose up -d
   docker compose ps   # confirmar que ambos servicios queden "healthy"
   ```

4. **Configurar la connection string vía user-secrets** (nunca en `appsettings.json`):

   ```bash
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:Default" "Host=localhost;Port=5432;Database=<POSTGRES_DB>;Username=<POSTGRES_USER>;Password=<POSTGRES_PASSWORD>"
   ```

   Usar los mismos valores que pusiste en `.env`.

5. **Instalar la herramienta de EF Core**

   ```bash
   dotnet tool install dotnet-ef
   ```

6. **Aplicar las migraciones:**

   ```bash
   dotnet ef database update
   ```

7. **Correr la API:**

   ```bash
   dotnet run
   ```

## Migraciones

```bash
dotnet ef migrations add <NombreDeLaMigracion>
dotnet ef database update
```

Las migraciones se generan/aplican a través de `Common/Data/AppDbContextFactory.cs`
(`IDesignTimeDbContextFactory<AppDbContext>`), no del `Program.cs` completo — esto evita
que los comandos de `dotnet ef` dependan de que `ASPNETCORE_ENVIRONMENT=Development` esté
seteado en la terminal para poder leer los user-secrets.

### Resetear la base de datos desde cero

```bash
docker compose down -v      # baja los contenedores y borra los volúmenes
rm -rf Migrations/
docker compose up -d
dotnet ef migrations add InitialCreate
dotnet ef database update
```
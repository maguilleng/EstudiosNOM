# EstudiosNOM — Backend Architecture

.NET Core 3.1 REST API for NOM occupational health study management.

## Solution structure

| Project | Path | Responsibility |
|---------|------|------------------|
| `ESTUDIOS` | `ESTUDIOS/` | ASP.NET Core host — controllers, `Startup.cs`, `Program.cs` |
| `Business` | `Business/` | Business logic; inherits `GenericBusiness<TDto, TEntity>` |
| `Contract.Business` | `Contract.Business/` | Interfaces (`IEstudiosBusiness`, `ILinksBusiness`, …) |
| `Data` | `Data/` | EF Core `ESTUDIOS_NOM35Context`, entities, repositories |
| `DTO` | `DTO/` | DTOs, `ApiResponse<T>`, enums (`EstudiosEnums`) |
| `EstudiosNOM.Tests` | `Tests/` | Unit tests (limited coverage) |

Solution file: `ESTUDIOS.sln`

## Request flow

```
HTTP Request
  → Controller (ESTUDIOS/Controllers/)
    → IBusiness interface (Contract.Business/)
      → Business class (Business/)
        → IRepository (Data/repositoryInterface/)
          → GenericRepository<T> (Data/repository/)
            → ESTUDIOS_NOM35Context (EF Core)
              → SQL Server
```

## Generic CRUD pattern

Most entities use generic base classes:

- **`GenericBusiness<TDto, TEntity>`** — `Add`, `Update`, `Delete`, `GetAll`; maps DTO ↔ entity via AutoMapper
- **`GenericRepository<T>`** — `Add`, `Update` (EF `dbSet.Update`), `Delete`, `FindBy`, `GetAll`

Custom logic extends the generic base:

- `EstudiosBusiness` — `getEstudiobyLink`, `updateEstudio` (partial field merge)
- `LinksBusiness` — `getLinks`, `getStatusLink`, `actualizaEstatusLink`

## AutoMapper

Profiles in `Business/automapperProfile/` (e.g. `EstudiosProfile.cs`) map between DTOs and EF entities.

## Dependency injection

Registered in `ESTUDIOS/Startup.cs`:

- `DbContext`: `ESTUDIOS_NOM35Context` with SQL Server connection string `"Database"`
- Repositories and business services registered per interface/implementation pair
- `EmailSettings`, `PdfExportSettings` from configuration sections

## Key entities

| Entity | Table | Notes |
|--------|-------|-------|
| `Estudio` | `ESTUDIOS` | Study campaign; FK to `Empresa` via RFC |
| `Link` | `LINKS` | Online survey GUID; FK `Idestudio` |
| `TrabajadoresEstudios` | — | Worker evaluations |
| `Empresa` | — | Companies (evaluated / evaluator) |

## Controllers

All under `api/[controller]`:

| Controller | Domain |
|------------|--------|
| `EstudiosController` | Studies CRUD + update |
| `LinksController` | Online links CRUD + status |
| `TrabajadoresEvaluadosController` | Evaluations |
| `EmpresasController` | Companies |
| `ActividadesController`, `TareasController` | NOM36 activities/tasks |
| `EVNOM036Controller`, `EVNOM36ResultadosController` | NOM36 questionnaires |
| `EVAYC*Controller` | Agents & conditions (light, thermal, sound, vibration) |
| `EVMuscoloesqueleticosController`, `EVNutricionalController` | Other evaluations |
| `NotificacionesController` | Email notifications for links |
| `ReportesController` | Word/Excel/PDF reports |

## Response patterns

- Some endpoints return raw entities (`GetEstudios` → `List<Estudio>`)
- Others wrap in `ApiResponse<T>` (`{ IsSuccesfull, ResponseData, ErrorDetails }`)
- Update endpoints often return `string` success message

## Configuration

- `appsettings.json` / `appsettings.Development.json` — connection string, email, PDF settings
- `authServer` — JWT authority (not in appsettings; injected at deploy)
- CORS: `AllowAnyOrigin()` in development/production

## Authentication (scaffolded, not enforced)

`Startup.cs` configures JWT Bearer but `UseAuthentication()` is not in the pipeline. No `[Authorize]` attributes on controllers.

## Adding a new endpoint

1. Add method to business interface (`Contract.Business/`)
2. Implement in `Business/` (extend generic or add custom logic)
3. Add controller action in `ESTUDIOS/Controllers/`
4. Add corresponding method in frontend `ApiService`

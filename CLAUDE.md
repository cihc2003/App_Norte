# Norte: contexto del proyecto

Aplicación web de finanzas personales. Proyecto final de SC-250 Paradigmas de Programación
(Universidad Fidélitas, Grupo 4). Este archivo es el contrato del repositorio: si una
instrucción choca con él, gana este archivo.

## Lo que evalúa el curso

El objetivo no es solo que la app funcione: **cada uno de los 5 paradigmas debe tener
evidencia clara en el código**. Si un framework oculta el paradigma, no cuenta.

| Paradigma | Dónde vive | Responsable |
|-----------|------------|-------------|
| Orientado a objetos | Entidades con comportamiento en `Norte.Abstracciones/Modelo` | Jessica |
| Funcional | Reglas puras con LINQ en `Norte.Reglas` (reportes) | Jurgen |
| Concurrente | `async`/`await`, `BackgroundService`, `Task.WhenAll`, concurrencia optimista (`xmin`) | Carlos |
| Orientado a eventos | Manejadores de eventos en React (`onSubmit`, `onChange`) | Jessica |
| Reactivo | Flujos RxJS en `web/norte-web/src/reactivo` | Mauricio |

Al escribir código para un paradigma, hacerlo visible y explicable; no esconderlo detrás
de abstracciones del framework.

## Stack fijo

.NET 10 (LTS), ASP.NET Core Web API con controladores, EF Core 10 + Npgsql, PostgreSQL 18,
React 19 + Vite (JavaScript), React Router, RxJS, Chart.js, xUnit. No cambiar versiones
mayores ni agregar ORMs, motores de BD o frameworks de UI sin acuerdo del grupo.

## Arquitectura en capas

```
Norte.Abstracciones  Entidades, DTOs e interfaces (API/, DA/, Flujo/, Reglas/, Servicios/, Modelo/)
Norte.DA             NorteDbContext, Configuraciones/ (una por entidad), <Entidad>DA
Norte.Reglas         Reglas de negocio puras: sin BD, sin HTTP, sin estado
Norte.Flujo          Casos de uso: orquestan DA + Reglas
Norte.Servicios      Tareas en segundo plano
Norte.Api            Controllers, filtro de excepciones, JWT, registro DI por módulo
```

- Todas las capas dependen de `Norte.Abstracciones`. Una interfaz por clase no estática.
- Dependencias por constructor; registrar en `Norte.Api/Configuracion/Modulos/Modulo<X>.cs`.
  No editar `Program.cs` para registrar clases de un módulo.
- Nombres: interfaces `I<Entidad>DA`, `I<Entidad>Flujo`, `IRegla<Nombre>`; clases sin la `I`.
- El módulo **Categorías** es la referencia completa en todas las capas.

## Reglas de código

- Toda E/S `async` con sufijo `Async`. Nunca `.Result` ni `.Wait()`.
- Lecturas con `AsNoTracking()`. Consultas en paralelo: `IDbContextFactory`, un contexto por tarea.
- Dinero en `decimal` (numeric(18,2)). Fechas sin hora en `DateOnly`; con hora, en UTC.
- Toda consulta de datos del usuario filtra por `UsuarioId` (de `IUsuarioActual`).
- Controllers sin lógica ni try/catch: lanzar `RecursoNoEncontradoException`,
  `ReglaNegocioException` o `ConflictoException`; el filtro devuelve 404, 400 o 409.
- La web solo presenta y pide datos; no calcula dinero. Todo HTTP pasa por `api/clienteHttp.js`.
  Estilos solo con las variables de `estilos/tokens.css`.
- Nombres en español y descriptivos. Comentarios solo para explicar el porqué.

## Comandos

```bash
dotnet build Norte.slnx
dotnet test
dotnet run --project src/Norte.Api --launch-profile http     # Swagger: /swagger
dotnet ef migrations add <Nombre> --project src/Norte.DA --startup-project src/Norte.Api  # solo Jurgen
dotnet ef database update --project src/Norte.DA --startup-project src/Norte.Api
cd web/norte-web && npm run dev | npm run build | npm run lint
```

## Git

Ramas `feature/modulo-<nombre>` desde `dev`; PR hacia `dev` revisado por otra persona;
`main` solo para entregas. Ver `CONTRIBUTING.md` y `docs/DIVISION_TRABAJO.md`.
Al cerrar un PR, agregar la entrada en `CHANGELOG.md`.

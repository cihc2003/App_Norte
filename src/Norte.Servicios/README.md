# Norte.Servicios

Tareas en segundo plano y servicios que no son de un solo módulo.

Aquí va la evidencia principal del **paradigma concurrente** (responsable: Carlos):

- `GeneradorPagosRecurrentesTarea`: un `BackgroundService` que cada día, con un
  `PeriodicTimer`, llama a `IProcesadorPagosRecurrentes.GenerarPagosDelDiaAsync`.
- Como un `BackgroundService` es singleton y el `DbContext` es por solicitud, la tarea
  debe crear un scope (`IServiceScopeFactory.CreateAsyncScope()`) en cada ejecución.
- Se registra en `ModuloDeudas` con `servicios.AddHostedService<GeneradorPagosRecurrentesTarea>()`.

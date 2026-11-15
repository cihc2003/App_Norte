# Interfaces de acceso a datos (DA)

Una interfaz por entidad, con nombre `I<Entidad>DA` (patrón del proyecto anterior).
Cada responsable crea la suya al empezar su módulo:

| Interfaz | Módulo | Responsable |
|----------|--------|-------------|
| `ICategoriaDA` | Categorías (referencia) | Hecha en el esqueleto |
| `IUsuarioDA` | Autenticación | Jurgen |
| `ITransaccionDA` | Movimientos | Jessica |
| `IMetaAhorroDA` | Metas de ahorro | Jessica |
| `IDeudaDA` | Deudas y pagos recurrentes | Carlos |
| `IPresupuestoDA` | Presupuestos | Mauricio |
| `IReporteDA` | Dashboard y reportes | Jurgen |

Reglas: todos los métodos son `async` con sufijo `Async`, y todo método que lee datos de
un usuario recibe `usuarioId` y filtra por él.

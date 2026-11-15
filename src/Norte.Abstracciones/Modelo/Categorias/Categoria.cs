using Norte.Abstracciones.Modelo.Comun;

namespace Norte.Abstracciones.Modelo.Categorias;

/// <summary>
/// Catálogo compartido (Comida, Transporte, Salario...). Lo usan Movimientos y Presupuestos.
/// Es el módulo de referencia del esqueleto: copien su estructura en cada capa.
/// </summary>
public class Categoria
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public TipoMovimiento Tipo { get; set; }
}

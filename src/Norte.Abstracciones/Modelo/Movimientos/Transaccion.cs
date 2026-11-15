using Norte.Abstracciones.Modelo.Comun;

namespace Norte.Abstracciones.Modelo.Movimientos;

/// <summary>
/// Un ingreso o gasto del usuario. Módulo Movimientos.
/// Responsable: Jessica. Paradigma orientado a objetos: agregar aquí el comportamiento
/// propio de la entidad (por ejemplo, validar que el monto sea positivo al crearla).
/// </summary>
public class Transaccion
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid CategoriaId { get; set; }
    public TipoMovimiento Tipo { get; set; }

    /// <summary>Dinero siempre en decimal, nunca double/float (riesgo 3).</summary>
    public decimal Monto { get; set; }

    /// <summary>Fecha del movimiento sin hora (riesgo 4).</summary>
    public DateOnly Fecha { get; set; }

    public string? Descripcion { get; set; }
    public DateTime FechaRegistroUtc { get; set; }
}

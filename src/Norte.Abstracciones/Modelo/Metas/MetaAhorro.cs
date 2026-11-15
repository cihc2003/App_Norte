namespace Norte.Abstracciones.Modelo.Metas;

/// <summary>
/// Objetivo de ahorro con monto y fecha límite. Módulo Metas de ahorro.
/// Responsable: Jessica. Agregar aquí el comportamiento: RegistrarAporte(monto),
/// MontoAhorrado y EstaCompletada.
/// </summary>
public class MetaAhorro
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal MontoObjetivo { get; set; }
    public DateOnly FechaLimite { get; set; }

    /// <summary>Token de concurrencia optimista (columna xmin de PostgreSQL, riesgo 6).</summary>
    public uint Version { get; set; }

    public List<AporteMeta> Aportes { get; set; } = new();
}

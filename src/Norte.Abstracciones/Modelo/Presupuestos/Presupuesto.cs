namespace Norte.Abstracciones.Modelo.Presupuestos;

/// <summary>
/// Límite mensual de gasto para una categoría. Módulo Presupuestos.
/// Responsable: Mauricio. Agregar aquí el comportamiento: PorcentajeUsado(gastado)
/// y EstaExcedido(gastado).
/// </summary>
public class Presupuesto
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid CategoriaId { get; set; }
    public int Anio { get; set; }
    public int Mes { get; set; }
    public decimal MontoLimite { get; set; }

    /// <summary>Token de concurrencia optimista (columna xmin de PostgreSQL, riesgo 6).</summary>
    public uint Version { get; set; }
}

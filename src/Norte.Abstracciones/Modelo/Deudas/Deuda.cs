namespace Norte.Abstracciones.Modelo.Deudas;

/// <summary>
/// Tarjeta, préstamo, mensualidad o suscripción. Módulo Deudas y pagos recurrentes.
/// Responsable: Carlos. Agregar aquí el comportamiento: RegistrarPago(monto) y
/// CalcularEstado(hoy) que devuelva AlDia / Pendiente / Atrasado.
/// </summary>
public class Deuda
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public TipoDeuda Tipo { get; set; }
    public decimal MontoTotal { get; set; }
    public decimal MontoPendiente { get; set; }
    public DateOnly FechaVencimiento { get; set; }
    public bool EsRecurrente { get; set; }

    /// <summary>Token de concurrencia optimista (columna xmin de PostgreSQL, riesgo 6).</summary>
    public uint Version { get; set; }

    public List<PagoDeuda> Pagos { get; set; } = new();
}

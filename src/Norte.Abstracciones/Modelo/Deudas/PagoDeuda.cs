namespace Norte.Abstracciones.Modelo.Deudas;

public class PagoDeuda
{
    public Guid Id { get; set; }
    public Guid DeudaId { get; set; }
    public decimal Monto { get; set; }
    public DateOnly Fecha { get; set; }

    /// <summary>true si lo generó la tarea en segundo plano de pagos recurrentes.</summary>
    public bool EsAutomatico { get; set; }
}

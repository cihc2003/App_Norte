namespace Norte.Abstracciones.Servicios;

/// <summary>
/// Genera los pagos de las deudas recurrentes que vencen en la fecha indicada.
/// Lo ejecuta la tarea en segundo plano (paradigma concurrente). Responsable: Carlos.
/// </summary>
public interface IProcesadorPagosRecurrentes
{
    Task<int> GenerarPagosDelDiaAsync(DateOnly hoy, CancellationToken cancelacion);
}

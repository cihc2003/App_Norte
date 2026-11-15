namespace Norte.Abstracciones.Modelo.Usuarios;

/// <summary>
/// Dueño de toda la información financiera. Toda consulta se filtra por UsuarioId
/// para aislar los datos entre usuarios (riesgo 7).
/// </summary>
public class Usuario
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string HashContrasena { get; set; } = string.Empty;

    /// <summary>Siempre en UTC (riesgo 4).</summary>
    public DateTime FechaRegistroUtc { get; set; }
}

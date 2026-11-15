namespace Norte.Api.Configuracion.Modulos;

/// <summary>
/// Deudas, pagos y la tarea en segundo plano de pagos recurrentes (AddHostedService).
/// Responsable: Carlos. Registre aquí sus DA, Reglas y Flujos, igual que en ModuloCategorias.
/// </summary>
public static class ModuloDeudas
{
    public static IServiceCollection AgregarModuloDeudas(this IServiceCollection servicios)
    {
        // TODO (Carlos): servicios.AddScoped<IXxxDA, XxxDA>(); etc.
        return servicios;
    }
}

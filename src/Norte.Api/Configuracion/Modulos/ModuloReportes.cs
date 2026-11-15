namespace Norte.Api.Configuracion.Modulos;

/// <summary>
/// Dashboard y reportes (consultas en paralelo con IDbContextFactory).
/// Responsable: Jurgen. Registre aquí sus DA, Reglas y Flujos, igual que en ModuloCategorias.
/// </summary>
public static class ModuloReportes
{
    public static IServiceCollection AgregarModuloReportes(this IServiceCollection servicios)
    {
        // TODO (Jurgen): servicios.AddScoped<IXxxDA, XxxDA>(); etc.
        return servicios;
    }
}

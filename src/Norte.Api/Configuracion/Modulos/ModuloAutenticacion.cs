namespace Norte.Api.Configuracion.Modulos;

/// <summary>
/// Registro, inicio de sesión y generación del token JWT.
/// Responsable: Jurgen. Registre aquí sus DA, Reglas y Flujos, igual que en ModuloCategorias.
/// </summary>
public static class ModuloAutenticacion
{
    public static IServiceCollection AgregarModuloAutenticacion(this IServiceCollection servicios)
    {
        // TODO (Jurgen): servicios.AddScoped<IXxxDA, XxxDA>(); etc.
        return servicios;
    }
}

using Norte.Abstracciones.DA;
using Norte.Abstracciones.Flujo;
using Norte.Abstracciones.Reglas;
using Norte.DA;
using Norte.Flujo;
using Norte.Reglas;

namespace Norte.Api.Configuracion.Modulos;

/// <summary>Módulo de referencia ya terminado. Úsenlo de ejemplo.</summary>
public static class ModuloCategorias
{
    public static IServiceCollection AgregarModuloCategorias(this IServiceCollection servicios)
    {
        servicios.AddScoped<ICategoriaDA, CategoriaDA>();
        servicios.AddScoped<ICategoriaFlujo, CategoriaFlujo>();

        // Regla compartida por todos los módulos que manejan montos.
        servicios.AddScoped<IReglaMontoPositivo, ReglaMontoPositivo>();
        return servicios;
    }
}

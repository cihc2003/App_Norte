using Norte.Abstracciones.DA;
using Norte.Abstracciones.Flujo;
using Norte.Abstracciones.Modelo.Categorias;
using Norte.Abstracciones.Modelo.Comun;

namespace Norte.Flujo;

/// <summary>
/// Flujo de referencia: recibe sus dependencias por interfaz, llama al DA y
/// transforma entidades a DTOs. Copien esta forma en cada módulo.
/// </summary>
public class CategoriaFlujo : ICategoriaFlujo
{
    private readonly ICategoriaDA _categoriaDA;

    public CategoriaFlujo(ICategoriaDA categoriaDA)
    {
        _categoriaDA = categoriaDA;
    }

    public async Task<IReadOnlyList<CategoriaRespuestaDto>> ListarAsync(TipoMovimiento? tipo)
    {
        var categorias = await _categoriaDA.ListarAsync(tipo);
        return categorias.Select(ADto).ToList();
    }

    public async Task<CategoriaRespuestaDto> ObtenerPorIdAsync(Guid id)
    {
        var categoria = await _categoriaDA.ObtenerPorIdAsync(id)
            ?? throw new RecursoNoEncontradoException("la categoría", id);
        return ADto(categoria);
    }

    private static CategoriaRespuestaDto ADto(Categoria categoria) =>
        new(categoria.Id, categoria.Nombre, categoria.Tipo);
}

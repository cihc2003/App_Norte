using Norte.Abstracciones.Modelo.Categorias;
using Norte.Abstracciones.Modelo.Comun;

namespace Norte.Abstracciones.Flujo;

public interface ICategoriaFlujo
{
    Task<IReadOnlyList<CategoriaRespuestaDto>> ListarAsync(TipoMovimiento? tipo);
    Task<CategoriaRespuestaDto> ObtenerPorIdAsync(Guid id);
}

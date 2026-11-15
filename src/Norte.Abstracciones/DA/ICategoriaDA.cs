using Norte.Abstracciones.Modelo.Categorias;
using Norte.Abstracciones.Modelo.Comun;

namespace Norte.Abstracciones.DA;

public interface ICategoriaDA
{
    Task<IReadOnlyList<Categoria>> ListarAsync(TipoMovimiento? tipo);
    Task<Categoria?> ObtenerPorIdAsync(Guid id);
}

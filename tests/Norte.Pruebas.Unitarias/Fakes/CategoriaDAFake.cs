using Norte.Abstracciones.DA;
using Norte.Abstracciones.Modelo.Categorias;
using Norte.Abstracciones.Modelo.Comun;

namespace Norte.Pruebas.Unitarias.Fakes;

/// <summary>DA en memoria: las pruebas del Flujo no tocan la base de datos.</summary>
public class CategoriaDAFake : ICategoriaDA
{
    private readonly List<Categoria> _categorias;

    public CategoriaDAFake(params Categoria[] categorias)
    {
        _categorias = categorias.ToList();
    }

    public Task<IReadOnlyList<Categoria>> ListarAsync(TipoMovimiento? tipo) =>
        Task.FromResult<IReadOnlyList<Categoria>>(
            _categorias.Where(c => tipo is null || c.Tipo == tipo).ToList());

    public Task<Categoria?> ObtenerPorIdAsync(Guid id) =>
        Task.FromResult(_categorias.FirstOrDefault(c => c.Id == id));
}

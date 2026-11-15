using Microsoft.EntityFrameworkCore;
using Norte.Abstracciones.DA;
using Norte.Abstracciones.Modelo.Categorias;
using Norte.Abstracciones.Modelo.Comun;
using Norte.DA.Contexto;

namespace Norte.DA;

/// <summary>
/// DA de referencia: recibe el DbContext por constructor, consulta con LINQ y
/// usa siempre los métodos asíncronos de EF Core (ToListAsync, FirstOrDefaultAsync...).
/// Las lecturas usan AsNoTracking porque no se van a modificar.
/// </summary>
public class CategoriaDA : ICategoriaDA
{
    private readonly NorteDbContext _contexto;

    public CategoriaDA(NorteDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<IReadOnlyList<Categoria>> ListarAsync(TipoMovimiento? tipo)
    {
        var consulta = _contexto.Categorias.AsNoTracking();

        if (tipo.HasValue)
            consulta = consulta.Where(c => c.Tipo == tipo.Value);

        return await consulta.OrderBy(c => c.Nombre).ToListAsync();
    }

    public async Task<Categoria?> ObtenerPorIdAsync(Guid id) =>
        await _contexto.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
}

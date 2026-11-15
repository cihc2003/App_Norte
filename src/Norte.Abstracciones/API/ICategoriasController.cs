using Microsoft.AspNetCore.Mvc;
using Norte.Abstracciones.Modelo.Comun;

namespace Norte.Abstracciones.API;

public interface ICategoriasController
{
    Task<IActionResult> ListarAsync(TipoMovimiento? tipo);
    Task<IActionResult> ObtenerPorIdAsync(Guid id);
}

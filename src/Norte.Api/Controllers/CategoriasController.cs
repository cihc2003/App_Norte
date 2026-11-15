using Microsoft.AspNetCore.Mvc;
using Norte.Abstracciones.API;
using Norte.Abstracciones.Flujo;
using Norte.Abstracciones.Modelo.Comun;

namespace Norte.Api.Controllers;

/// <summary>
/// Controller de referencia: solo recibe, delega al Flujo y responde.
/// Las categorías son un catálogo público; los demás controllers llevan [Authorize]
/// y obtienen el usuario con IUsuarioActual.
/// </summary>
[ApiController]
[Route("api/categorias")]
[Produces("application/json")]
public class CategoriasController : ControllerBase, ICategoriasController
{
    private readonly ICategoriaFlujo _categoriaFlujo;

    public CategoriasController(ICategoriaFlujo categoriaFlujo)
    {
        _categoriaFlujo = categoriaFlujo;
    }

    /// <summary>Lista las categorías; opcionalmente solo las de ingreso o las de gasto.</summary>
    [HttpGet]
    public async Task<IActionResult> ListarAsync([FromQuery] TipoMovimiento? tipo) =>
        Ok(await _categoriaFlujo.ListarAsync(tipo));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObtenerPorIdAsync([FromRoute] Guid id) =>
        Ok(await _categoriaFlujo.ObtenerPorIdAsync(id));
}

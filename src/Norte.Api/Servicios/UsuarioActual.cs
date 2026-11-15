using Norte.Abstracciones.Servicios;

namespace Norte.Api.Servicios;

public class UsuarioActual : IUsuarioActual
{
    // Claim estándar "sub" del JWT: lo emite el módulo de autenticación con el id del usuario.
    private const string ClaimIdUsuario = "sub";

    private readonly IHttpContextAccessor _accesoContexto;

    public UsuarioActual(IHttpContextAccessor accesoContexto)
    {
        _accesoContexto = accesoContexto;
    }

    public Guid ObtenerId()
    {
        var valor = _accesoContexto.HttpContext?.User.FindFirst(ClaimIdUsuario)?.Value;
        return Guid.TryParse(valor, out var id)
            ? id
            : throw new UnauthorizedAccessException("No hay un usuario autenticado.");
    }
}

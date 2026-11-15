namespace Norte.Abstracciones.Servicios;

/// <summary>
/// Da el id del usuario autenticado (sale del token JWT). Los controllers lo pasan
/// al Flujo para filtrar todo por usuario.
/// </summary>
public interface IUsuarioActual
{
    Guid ObtenerId();
}

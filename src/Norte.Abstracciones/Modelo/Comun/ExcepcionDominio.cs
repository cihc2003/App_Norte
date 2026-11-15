namespace Norte.Abstracciones.Modelo.Comun;

/// <summary>
/// Base de las excepciones de negocio. El filtro global del API las traduce
/// al código HTTP correcto, así los controllers no llevan try/catch.
/// </summary>
public abstract class ExcepcionDominio : Exception
{
    protected ExcepcionDominio(string mensaje) : base(mensaje) { }
}

/// <summary>Se traduce a 404 Not Found.</summary>
public class RecursoNoEncontradoException : ExcepcionDominio
{
    public RecursoNoEncontradoException(string recurso, Guid id)
        : base($"No se encontró {recurso} con id {id}.") { }
}

/// <summary>Se traduce a 400 Bad Request: una regla de negocio no se cumple.</summary>
public class ReglaNegocioException : ExcepcionDominio
{
    public ReglaNegocioException(string mensaje) : base(mensaje) { }
}

/// <summary>Se traduce a 409 Conflict: el dato ya existe o cambió mientras se editaba.</summary>
public class ConflictoException : ExcepcionDominio
{
    public ConflictoException(string mensaje) : base(mensaje) { }
}

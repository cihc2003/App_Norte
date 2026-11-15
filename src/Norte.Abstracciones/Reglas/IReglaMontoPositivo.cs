namespace Norte.Abstracciones.Reglas;

/// <summary>
/// Regla compartida: todo monto de dinero (movimiento, pago, límite, aporte) debe ser
/// mayor que cero y tener como máximo dos decimales.
/// </summary>
public interface IReglaMontoPositivo
{
    bool EsValido(decimal monto);
}

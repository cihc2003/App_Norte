using Norte.Abstracciones.Reglas;

namespace Norte.Reglas;

public class ReglaMontoPositivo : IReglaMontoPositivo
{
    private const int DecimalesPermitidos = 2;

    public bool EsValido(decimal monto) =>
        monto > 0 && decimal.Round(monto, DecimalesPermitidos) == monto;
}

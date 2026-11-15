using Norte.Reglas;

namespace Norte.Pruebas.Unitarias.Reglas;

public class ReglaMontoPositivoPruebas
{
    private readonly ReglaMontoPositivo _regla = new();

    [Theory]
    [InlineData(1)]
    [InlineData(15000.50)]
    public void EsValido_MontoPositivoConDosDecimales_DevuelveTrue(decimal monto) =>
        Assert.True(_regla.EsValido(monto));

    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    [InlineData(10.555)]
    public void EsValido_MontoCeroNegativoOConMasDeDosDecimales_DevuelveFalse(decimal monto) =>
        Assert.False(_regla.EsValido(monto));
}

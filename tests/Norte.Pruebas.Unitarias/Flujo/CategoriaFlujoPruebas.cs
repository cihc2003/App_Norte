using Norte.Abstracciones.Modelo.Categorias;
using Norte.Abstracciones.Modelo.Comun;
using Norte.Flujo;
using Norte.Pruebas.Unitarias.Fakes;

namespace Norte.Pruebas.Unitarias.Flujo;

public class CategoriaFlujoPruebas
{
    private static readonly Categoria Salario = new() { Id = Guid.NewGuid(), Nombre = "Salario", Tipo = TipoMovimiento.Ingreso };
    private static readonly Categoria Comida = new() { Id = Guid.NewGuid(), Nombre = "Comida", Tipo = TipoMovimiento.Gasto };

    [Fact]
    public async Task ListarAsync_ConTipoGasto_DevuelveSoloGastos()
    {
        var flujo = new CategoriaFlujo(new CategoriaDAFake(Salario, Comida));

        var resultado = await flujo.ListarAsync(TipoMovimiento.Gasto);

        Assert.Single(resultado);
        Assert.Equal("Comida", resultado[0].Nombre);
    }

    [Fact]
    public async Task ObtenerPorIdAsync_IdInexistente_LanzaRecursoNoEncontrado()
    {
        var flujo = new CategoriaFlujo(new CategoriaDAFake(Salario));

        await Assert.ThrowsAsync<RecursoNoEncontradoException>(() => flujo.ObtenerPorIdAsync(Guid.NewGuid()));
    }
}

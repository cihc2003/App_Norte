using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Norte.Abstracciones.Modelo.Categorias;
using Norte.Abstracciones.Modelo.Comun;

namespace Norte.DA.Configuraciones;

public class CategoriaConfiguracion : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> entidad)
    {
        entidad.ToTable("categorias");
        entidad.HasKey(c => c.Id);
        entidad.Property(c => c.Nombre).HasMaxLength(60).IsRequired();
        entidad.Property(c => c.Tipo).HasConversion<string>().HasMaxLength(10);
        entidad.HasData(CategoriasIniciales);
    }

    // Ids fijos para que la semilla no cambie en cada migración.
    private static readonly Categoria[] CategoriasIniciales =
    {
        new() { Id = Guid.Parse("8f0f6f3a-0001-4c1a-9a01-000000000001"), Nombre = "Salario", Tipo = TipoMovimiento.Ingreso },
        new() { Id = Guid.Parse("8f0f6f3a-0001-4c1a-9a01-000000000002"), Nombre = "Trabajo independiente", Tipo = TipoMovimiento.Ingreso },
        new() { Id = Guid.Parse("8f0f6f3a-0001-4c1a-9a01-000000000003"), Nombre = "Otros ingresos", Tipo = TipoMovimiento.Ingreso },
        new() { Id = Guid.Parse("8f0f6f3a-0001-4c1a-9a01-000000000004"), Nombre = "Alimentación", Tipo = TipoMovimiento.Gasto },
        new() { Id = Guid.Parse("8f0f6f3a-0001-4c1a-9a01-000000000005"), Nombre = "Transporte", Tipo = TipoMovimiento.Gasto },
        new() { Id = Guid.Parse("8f0f6f3a-0001-4c1a-9a01-000000000006"), Nombre = "Servicios", Tipo = TipoMovimiento.Gasto },
        new() { Id = Guid.Parse("8f0f6f3a-0001-4c1a-9a01-000000000007"), Nombre = "Entretenimiento", Tipo = TipoMovimiento.Gasto },
        new() { Id = Guid.Parse("8f0f6f3a-0001-4c1a-9a01-000000000008"), Nombre = "Suscripciones", Tipo = TipoMovimiento.Gasto },
        new() { Id = Guid.Parse("8f0f6f3a-0001-4c1a-9a01-000000000009"), Nombre = "Salud", Tipo = TipoMovimiento.Gasto },
        new() { Id = Guid.Parse("8f0f6f3a-0001-4c1a-9a01-00000000000a"), Nombre = "Educación", Tipo = TipoMovimiento.Gasto },
        new() { Id = Guid.Parse("8f0f6f3a-0001-4c1a-9a01-00000000000b"), Nombre = "Otros gastos", Tipo = TipoMovimiento.Gasto }
    };
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Norte.Abstracciones.Modelo.Categorias;
using Norte.Abstracciones.Modelo.Presupuestos;
using Norte.Abstracciones.Modelo.Usuarios;

namespace Norte.DA.Configuraciones;

public class PresupuestoConfiguracion : IEntityTypeConfiguration<Presupuesto>
{
    public void Configure(EntityTypeBuilder<Presupuesto> entidad)
    {
        entidad.ToTable("presupuestos");
        entidad.HasKey(p => p.Id);
        entidad.Property(p => p.Version).IsRowVersion();
        entidad.HasOne<Usuario>().WithMany().HasForeignKey(p => p.UsuarioId);
        entidad.HasOne<Categoria>().WithMany().HasForeignKey(p => p.CategoriaId);
        // Un solo presupuesto por categoría y mes para cada usuario.
        entidad.HasIndex(p => new { p.UsuarioId, p.CategoriaId, p.Anio, p.Mes }).IsUnique();
    }
}

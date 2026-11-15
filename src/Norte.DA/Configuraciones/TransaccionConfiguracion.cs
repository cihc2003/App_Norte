using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Norte.Abstracciones.Modelo.Categorias;
using Norte.Abstracciones.Modelo.Movimientos;
using Norte.Abstracciones.Modelo.Usuarios;

namespace Norte.DA.Configuraciones;

public class TransaccionConfiguracion : IEntityTypeConfiguration<Transaccion>
{
    public void Configure(EntityTypeBuilder<Transaccion> entidad)
    {
        entidad.ToTable("transacciones");
        entidad.HasKey(t => t.Id);
        entidad.Property(t => t.Tipo).HasConversion<string>().HasMaxLength(10);
        entidad.Property(t => t.Descripcion).HasMaxLength(250);
        entidad.HasOne<Usuario>().WithMany().HasForeignKey(t => t.UsuarioId);
        entidad.HasOne<Categoria>().WithMany().HasForeignKey(t => t.CategoriaId);
        // Consulta más común: los movimientos de un usuario en un rango de fechas.
        entidad.HasIndex(t => new { t.UsuarioId, t.Fecha });
    }
}

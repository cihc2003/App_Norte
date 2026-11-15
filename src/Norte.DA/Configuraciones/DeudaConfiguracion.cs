using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Norte.Abstracciones.Modelo.Deudas;
using Norte.Abstracciones.Modelo.Usuarios;

namespace Norte.DA.Configuraciones;

public class DeudaConfiguracion : IEntityTypeConfiguration<Deuda>
{
    public void Configure(EntityTypeBuilder<Deuda> entidad)
    {
        entidad.ToTable("deudas");
        entidad.HasKey(d => d.Id);
        entidad.Property(d => d.Nombre).HasMaxLength(100).IsRequired();
        entidad.Property(d => d.Tipo).HasConversion<string>().HasMaxLength(20);
        // Npgsql mapea un uint con IsRowVersion a la columna de sistema xmin (riesgo 6).
        entidad.Property(d => d.Version).IsRowVersion();
        entidad.HasOne<Usuario>().WithMany().HasForeignKey(d => d.UsuarioId);
        entidad.HasMany(d => d.Pagos).WithOne().HasForeignKey(p => p.DeudaId);
    }
}

public class PagoDeudaConfiguracion : IEntityTypeConfiguration<PagoDeuda>
{
    public void Configure(EntityTypeBuilder<PagoDeuda> entidad)
    {
        entidad.ToTable("pagos_deuda");
        entidad.HasKey(p => p.Id);
    }
}

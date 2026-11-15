using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Norte.Abstracciones.Modelo.Metas;
using Norte.Abstracciones.Modelo.Usuarios;

namespace Norte.DA.Configuraciones;

public class MetaAhorroConfiguracion : IEntityTypeConfiguration<MetaAhorro>
{
    public void Configure(EntityTypeBuilder<MetaAhorro> entidad)
    {
        entidad.ToTable("metas_ahorro");
        entidad.HasKey(m => m.Id);
        entidad.Property(m => m.Nombre).HasMaxLength(100).IsRequired();
        entidad.Property(m => m.Version).IsRowVersion();
        entidad.HasOne<Usuario>().WithMany().HasForeignKey(m => m.UsuarioId);
        entidad.HasMany(m => m.Aportes).WithOne().HasForeignKey(a => a.MetaAhorroId);
    }
}

public class AporteMetaConfiguracion : IEntityTypeConfiguration<AporteMeta>
{
    public void Configure(EntityTypeBuilder<AporteMeta> entidad)
    {
        entidad.ToTable("aportes_meta");
        entidad.HasKey(a => a.Id);
    }
}

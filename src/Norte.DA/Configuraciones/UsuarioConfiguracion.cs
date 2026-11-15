using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Norte.Abstracciones.Modelo.Usuarios;

namespace Norte.DA.Configuraciones;

public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> entidad)
    {
        entidad.ToTable("usuarios");
        entidad.HasKey(u => u.Id);
        entidad.Property(u => u.Nombre).HasMaxLength(100).IsRequired();
        entidad.Property(u => u.Correo).HasMaxLength(150).IsRequired();
        entidad.HasIndex(u => u.Correo).IsUnique();
        entidad.Property(u => u.HashContrasena).IsRequired();
    }
}

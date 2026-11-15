using Microsoft.EntityFrameworkCore;
using Norte.Abstracciones.Modelo.Categorias;
using Norte.Abstracciones.Modelo.Deudas;
using Norte.Abstracciones.Modelo.Metas;
using Norte.Abstracciones.Modelo.Movimientos;
using Norte.Abstracciones.Modelo.Presupuestos;
using Norte.Abstracciones.Modelo.Usuarios;

namespace Norte.DA.Contexto;

/// <summary>
/// Sesión con PostgreSQL. El mapeo de cada entidad vive en Configuraciones/ (una clase
/// por entidad) para que cada responsable edite solo su archivo.
/// Las migraciones las genera una sola persona (Jurgen) para evitar conflictos en el
/// ModelSnapshot (riesgo 5).
/// </summary>
public class NorteDbContext : DbContext
{
    public NorteDbContext(DbContextOptions<NorteDbContext> opciones) : base(opciones) { }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Transaccion> Transacciones => Set<Transaccion>();
    public DbSet<Deuda> Deudas => Set<Deuda>();
    public DbSet<PagoDeuda> PagosDeuda => Set<PagoDeuda>();
    public DbSet<Presupuesto> Presupuestos => Set<Presupuesto>();
    public DbSet<MetaAhorro> MetasAhorro => Set<MetaAhorro>();
    public DbSet<AporteMeta> AportesMeta => Set<AporteMeta>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NorteDbContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder convenciones)
    {
        // Todo decimal del modelo es dinero: numeric(18,2) exacto (riesgo 3).
        convenciones.Properties<decimal>().HavePrecision(18, 2);
    }
}

namespace Norte.Abstracciones.Modelo.Metas;

public class AporteMeta
{
    public Guid Id { get; set; }
    public Guid MetaAhorroId { get; set; }
    public decimal Monto { get; set; }
    public DateOnly Fecha { get; set; }
}

namespace SGE.Aplicacion;

public class Expediente
{
    public int IdExpediente { get; set; }
    public string? Caratula { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int UsuarioUltModificacion { get; set; }
    public EstadoExpediente Estado { get; set; }
    public List<Tramite>? listaDeTramites { get; set; }

    public Expediente(string c)
        : this()
    {
        Caratula = c;
    }

    public Expediente()
    {
        FechaCreacion = DateTime.Now;
        FechaModificacion = DateTime.Now;
        Estado = EstadoExpediente.RecienIniciado;
    }
}

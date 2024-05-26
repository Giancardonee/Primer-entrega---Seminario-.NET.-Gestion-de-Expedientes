using System.Dynamic;
using System.Text.RegularExpressions;

namespace SGE.Aplicacion;

public class Tramite
{
    public int IdTramite { get; set; }
    public int ExpedienteID { get; set; }
    public EtiquetaTramite TipoTramite { get; set; }
    public string ContenidoTramite { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltModificacion { get; set; }
    public int UsuarioUltModificacion { get; set; }

    public Tramite(int ExpId, EtiquetaTramite etiqueta, string contenido)
        : this()
    {
        ExpedienteID = ExpId;
        TipoTramite = etiqueta;
        ContenidoTramite = contenido;
    }

    public Tramite()
    {
        TipoTramite = EtiquetaTramite.EscritoPresentado;
        FechaCreacion = DateTime.Now;
        FechaUltModificacion = DateTime.Now;
        ContenidoTramite="";
    }

    public override string ToString()
    {
        return $"Id de Expediente: {ExpedienteID}, Id de tramite: {IdTramite}, Tipo de tramite: {TipoTramite} , Contenido del tramite: {ContenidoTramite}  ";
    }
}

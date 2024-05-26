namespace SGE.Aplicacion;

public class EspecificacionCambioEstado
{
    public EstadoExpediente cambioEstadoExpediente(EtiquetaTramite etiqueta, EstadoExpediente e)
    {
        switch (etiqueta)
        {
            case EtiquetaTramite.Resolucion:
                return EstadoExpediente.ConResolucion;
            case EtiquetaTramite.PaseAEstudio:
                return EstadoExpediente.ParaResolver;
            case EtiquetaTramite.PaseAlArchivo:
                return EstadoExpediente.Finalizado;
            default: 
               return e;
        }
    }
}

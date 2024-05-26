namespace SGE.Aplicacion;

public class ServicioActualizacionEstado(EspecificacionCambioEstado especificacionCambioEstado, IExpedienteRepositorio repoExpediente)
{
    public void actualizacionEstadoExpediente(int IdExpediente, EtiquetaTramite etiqueta) {
       Expediente? exp = repoExpediente.ExpedienteConsultaPorId(IdExpediente);
       if (exp != null) 
       {
        exp.Estado = especificacionCambioEstado.cambioEstadoExpediente(etiqueta, exp.Estado);
        repoExpediente.ExpedienteModificacion(exp);
       }
    }
}

namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void ExpedienteAlta(Expediente expAlta);
    void ExpedienteBaja(int idBaja); 
    void ExpedienteModificacion(Expediente expModificacion);
    Expediente? ExpedienteConsultaPorId(int IdExpediente);
    List<Expediente> ExpedienteConsultaTodos();
}

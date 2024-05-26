namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos (IExpedienteRepositorio repoExpediente)
{
    public List<Expediente> Ejecutar()
    {
         return repoExpediente.ExpedienteConsultaTodos(); 
    } 


}

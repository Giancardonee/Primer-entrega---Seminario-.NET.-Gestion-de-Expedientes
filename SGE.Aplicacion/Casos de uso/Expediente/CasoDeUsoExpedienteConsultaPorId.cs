namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repoExpediente)
{
    public Expediente? Ejecutar(int idConsulta)
    {
        return repoExpediente.ExpedienteConsultaPorId(idConsulta);
    } 
}

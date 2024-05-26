namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConTramitesAsociados(IExpedienteRepositorio repoExpediente, ITramiteRepositorio repoTramite)
{
    public Expediente? Ejecutar(int idExpediente)
    {
        Expediente? exp = repoExpediente.ExpedienteConsultaPorId(idExpediente);
        if (exp != null)
            exp.listaDeTramites = repoTramite.TramiteConsultaPorIdExpediente(idExpediente);
        return exp;
    }
}

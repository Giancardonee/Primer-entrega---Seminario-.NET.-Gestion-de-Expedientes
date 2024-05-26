namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(
    IExpedienteRepositorio repoExpediente,
    IServicioAutorizacion autorizador,
    ITramiteRepositorio repoTramite
)
{
    public void Ejecutar(int idBaja, int IdUsuario)
    {
        try
        {
            if (autorizador.TienePermiso(IdUsuario, Permiso.ExpedienteBaja))
            {
                List<Tramite> listaTramites = repoTramite.TramiteConsultaPorIdExpediente(idBaja);
                if (listaTramites.Count > 0)
                    repoTramite.eliminarTramitesAsociados(idBaja);
                repoExpediente.ExpedienteBaja(idBaja);
            }
            else
            {
                throw new AutorizacionException();
            }
        }
        catch (AutorizacionException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

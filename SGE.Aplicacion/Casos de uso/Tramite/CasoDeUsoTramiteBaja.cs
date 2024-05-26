namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(
    ITramiteRepositorio repoTramite,
    IServicioAutorizacion autorizador,
    ServicioActualizacionEstado actualizacionEstado
)
{
    public void Ejecutar(int idTramite, int IdUsuario)
    {
        try
        {
            if (autorizador.TienePermiso(IdUsuario, Permiso.TramiteBaja))
            {
                Tramite ultimoTramite = repoTramite.TramiteConsultaUltimo();                
                repoTramite.TramiteBaja(idTramite);
                if (ultimoTramite.IdTramite == idTramite)
                {
                    Tramite nuevoUltTramite = repoTramite.TramiteConsultaUltimo();
                    if (nuevoUltTramite.IdTramite > 0) 
                        actualizacionEstado.actualizacionEstadoExpediente(nuevoUltTramite.ExpedienteID, nuevoUltTramite.TipoTramite);
                }
            }
            else
                throw new AutorizacionException();
        }
        catch (AutorizacionException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

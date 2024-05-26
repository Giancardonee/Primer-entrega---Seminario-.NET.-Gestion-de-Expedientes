namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(
    ITramiteRepositorio repoTramite,
    IServicioAutorizacion autorizador,
    ServicioActualizacionEstado actualizacionEstado
)
{
    public void Ejecutar(Tramite t, int IdUsuario)
    {
        try
        {
            if (autorizador.TienePermiso(IdUsuario, Permiso.TramiteModificacion))
            {
                repoTramite.TramiteModificacion(t);
                actualizacionEstado.actualizacionEstadoExpediente(t.ExpedienteID, t.TipoTramite);
            }
            else throw new AutorizacionException(); 
        }
        catch (AutorizacionException e)
        {
            Console.WriteLine(e.Message); 
        }
    }
}

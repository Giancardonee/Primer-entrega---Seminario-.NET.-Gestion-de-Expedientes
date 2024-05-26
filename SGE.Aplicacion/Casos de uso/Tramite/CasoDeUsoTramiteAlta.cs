namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta (ITramiteRepositorio repoTramite, IServicioAutorizacion autorizador,ServicioActualizacionEstado actualizacionEstado)
{
    public void Ejecutar (Tramite t, int IdUsuario)
    {
        try
        {
            if(autorizador.TienePermiso(IdUsuario, Permiso.TramiteAlta)) {
                t.FechaCreacion = DateTime.Now;
                t.FechaUltModificacion = DateTime.Now;
                t.UsuarioUltModificacion = IdUsuario;
                repoTramite.TramiteAlta(t); 
                actualizacionEstado.actualizacionEstadoExpediente(t.ExpedienteID, t.TipoTramite);
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

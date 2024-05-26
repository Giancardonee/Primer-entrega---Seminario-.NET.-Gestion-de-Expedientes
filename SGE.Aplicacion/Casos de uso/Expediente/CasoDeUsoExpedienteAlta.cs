namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta (IExpedienteRepositorio repoExpediente, IServicioAutorizacion autorizador)
{

    public void Ejecutar(Expediente e, int IdUsuario)
    {
        try 
        {
            if(autorizador.TienePermiso(IdUsuario, Permiso.ExpedienteAlta)){
            e.UsuarioUltModificacion = IdUsuario;
            repoExpediente.ExpedienteAlta(e);
            }
            else
            {
                throw new AutorizacionException();
            }
        }

        catch (AutorizacionException error)
        {
            Console.WriteLine(error.Message); 
        }
    }

}

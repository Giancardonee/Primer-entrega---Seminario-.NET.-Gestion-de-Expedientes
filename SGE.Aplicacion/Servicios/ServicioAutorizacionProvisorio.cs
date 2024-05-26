namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
  public bool TienePermiso(int IdUsuario, Permiso permiso)
    {   
        return IdUsuario == 1; 
    }
}

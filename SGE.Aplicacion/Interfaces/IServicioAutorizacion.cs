namespace SGE.Aplicacion;

public interface IServicioAutorizacion
{
    bool TienePermiso(int IdUsuario, Permiso permiso);
}

namespace SGE.Aplicacion;

public class TramiteValidador
{
    public static void Validar (Tramite t)
    {
      string msj="";
      if (string.IsNullOrEmpty(t.ContenidoTramite)) 
        msj="El contenido de un tramite no puede estar vacío. ";
      if (t.UsuarioUltModificacion <=0) 
        msj +="el id de usuario debe ser un id válido (entero mayor que 0)";

      if (msj !="")throw new ValidacionException(msj);
    }
}

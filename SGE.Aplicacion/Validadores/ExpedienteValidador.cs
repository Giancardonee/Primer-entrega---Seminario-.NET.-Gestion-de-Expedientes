using System.ComponentModel.DataAnnotations;

namespace SGE.Aplicacion;

public static class ExpedienteValidador
{ 
    public static void Validar (Expediente e)
    {
      string msj="";
      if (string.IsNullOrEmpty(e.Caratula)) 
        msj="La carátula de un expediente no puede estar vacía. ";
      if (e.UsuarioUltModificacion <=0) 
        msj +="el id de usuario debe ser un id válido (entero mayor que 0)";

      if (msj !="") throw new ValidacionException(msj);
    }
}

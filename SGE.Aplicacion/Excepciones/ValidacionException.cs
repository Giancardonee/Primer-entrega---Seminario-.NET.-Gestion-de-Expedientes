namespace SGE.Aplicacion;

public class ValidacionException : Exception
{
    public ValidacionException(string message)  : base(message)
    {
        
    }
     public ValidacionException()  : base("Error de validación: la entidad no cumple con los requisitos exigidos.")
    {
        
    }
}

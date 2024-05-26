namespace SGE.Aplicacion;

public class RepositorioException : Exception
{
    public RepositorioException(string message)  : base(message)
    {
        
    }
      public RepositorioException()  : base("Error de Repositorio: la entidad no existe.")
    {
        
    }
}

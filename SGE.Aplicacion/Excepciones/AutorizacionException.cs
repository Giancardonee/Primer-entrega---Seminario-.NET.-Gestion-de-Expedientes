namespace SGE.Aplicacion;

public class AutorizacionException : Exception
{
    public AutorizacionException(string message)
        : base(message) { }

    public AutorizacionException()
        : base("Error de autorización: No tiene permisos.") { }
}

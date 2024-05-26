using System.Numerics;
using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
    static readonly string _nombreArch = "Expedientes.txt";
    static int contadorExpedientes = contadorActual();

    public void ExpedienteAlta(Expediente e)
    {
        try
        {
            ExpedienteValidador.Validar(e);
            using var sw = new StreamWriter(_nombreArch, true);
            e.IdExpediente = ++contadorExpedientes;
            escribirValores(e, sw);
        }
        catch (ValidacionException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (Exception exc2)
        {
            Console.WriteLine(exc2);
        }
    }

    public void ExpedienteBaja(int idBorrarExpediente)
    {
        try
        {
            bool encontre = false;
            List<Expediente> listaExpediente = new List<Expediente>();
            using var sr = new StreamReader(_nombreArch, true);
            while (!sr.EndOfStream)
            {
                Expediente eActual = leerExpediente(sr);
                if (eActual.IdExpediente != idBorrarExpediente)
                    listaExpediente.Add(eActual);
                else
                    encontre = true;
            }
            if (encontre)
            {
                sr.Dispose();
                actualizarArchivo(listaExpediente);
            }
            else
                throw new RepositorioException(
                    "ExpedienteBaja: El expediente que se intenta eliminar no existe."
                );
        }
        catch (RepositorioException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void ExpedienteModificacion(Expediente eModificar)
    {
        bool encontre = false;
        List<Expediente> listaExpediente = new List<Expediente>();
        try
        {
            using var sr = new StreamReader(_nombreArch, true);
            while (!sr.EndOfStream)
            {
                Expediente eActual = leerExpediente(sr);
                if (eActual.IdExpediente == eModificar.IdExpediente)
                {
                    eActual.Caratula = eModificar.Caratula;
                    eActual.Estado = eModificar.Estado;
                    encontre = true;
                }
                listaExpediente.Add(eActual);
            }
            if (encontre)
            {
                sr.Dispose();
                actualizarArchivo(listaExpediente);
            }
            else
                throw new RepositorioException();
        }
        catch (RepositorioException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public Expediente? ExpedienteConsultaPorId(int IdExpediente)
    {
        try
        {
            Expediente resultado = new Expediente();
            using var sr = new StreamReader(_nombreArch, true);
            resultado = leerExpediente(sr);
            while (!sr.EndOfStream && resultado.IdExpediente != IdExpediente)
            {
                resultado = leerExpediente(sr);
            }
            if (resultado.IdExpediente == IdExpediente)
            {
                return resultado;
            }
            else
            {
                throw new RepositorioException("ExpedienteConsultaPorId: el expediente no existe.");
            }
        }
        catch (RepositorioException ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public List<Expediente> ExpedienteConsultaTodos()
    {
        List<Expediente> expedientes = new List<Expediente>();
        try
        {
            using var sr = new StreamReader(_nombreArch, true);
            while (!sr.EndOfStream)
            {
                expedientes.Add(leerExpediente(sr));
            }
            if (expedientes.Count == 0)
                throw new RepositorioException();
        }
        catch (RepositorioException exp)
        {
            Console.WriteLine(exp.Message);
        }
        return expedientes;
    }

    //==================== metodos privados
    private Expediente leerExpediente(StreamReader sr)
    {
        Expediente e = new Expediente();
        string? id = sr.ReadLine();
        if (!String.IsNullOrEmpty(id))
        {
            e.IdExpediente = int.Parse(id);
            e.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
            e.FechaModificacion = DateTime.Parse(sr.ReadLine() ?? "");
            e.Caratula = sr.ReadLine() ?? "";
            e.Estado = Enum.Parse<EstadoExpediente>(sr.ReadLine() ?? "");
            e.UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "");
        }
        else
        {
            throw new RepositorioException("leerExpediente: El archivo está vacío");
        }
        return e;
    }

    private void actualizarArchivo(List<Expediente> listaExpedientes)
    {
        try
        {
            if (File.Exists(_nombreArch))
            {
                File.Delete(_nombreArch);
                using var sw = new StreamWriter(_nombreArch, true);
                foreach (Expediente e in listaExpedientes)
                {
                    escribirValores(e, sw);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al actualizar el archivo. Error " + e.Message);
        }
    }

    private static int contadorActual()
    {
        using var sr = new StreamReader(_nombreArch, true);
        int ultimoId = 0;
        while (!sr.EndOfStream)
        {
            string? id = sr.ReadLine();
            if (!String.IsNullOrEmpty(id))
            {
                ultimoId = Int32.Parse(id);
                for (int i = 1; i < 6; i++)
                {
                    sr.ReadLine();
                }
            }
        }
        return ultimoId;
    }

    private void escribirValores(Expediente e, StreamWriter sw)
    {
        sw.WriteLine(e.IdExpediente);
        sw.WriteLine(e.FechaCreacion);
        sw.WriteLine(e.FechaModificacion);
        sw.WriteLine(e.Caratula);
        sw.WriteLine(e.Estado);
        sw.WriteLine(e.UsuarioUltModificacion);
    }
}

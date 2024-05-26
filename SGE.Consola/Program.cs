using System;
using SGE.Aplicacion;
using SGE.Repositorios;

namespace SGE.Consola;

class Program
{
    static void Main(string[] args)
    {
        IExpedienteRepositorio repoExpediente = new RepositorioExpedienteTXT();
        ITramiteRepositorio repoTramite = new RepositorioTramiteTxt();
        IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();
        EspecificacionCambioEstado espCambioEstado = new EspecificacionCambioEstado();
        ServicioActualizacionEstado servActEstado = new ServicioActualizacionEstado(
            espCambioEstado,
            repoExpediente
        );
        CasoDeUsoExpedienteAlta CUEAlta = new CasoDeUsoExpedienteAlta(
            repoExpediente,
            servicioAutorizacion
        );
        CasoDeUsoExpedienteBaja CUEBaja = new CasoDeUsoExpedienteBaja(
            repoExpediente,
            servicioAutorizacion,
            repoTramite
        );
        CasoDeUsoExpedienteModificacion CUEModificacion = new CasoDeUsoExpedienteModificacion(
            repoExpediente,
            servicioAutorizacion
        );
        CasoDeUsoExpedienteConsultaPorId CUEConsultaPorId = new CasoDeUsoExpedienteConsultaPorId(
            repoExpediente
        );
        CasoDeUsoExpedienteConsultaTodos CUEConsultaTodos = new CasoDeUsoExpedienteConsultaTodos(
            repoExpediente
        );
        CasoDeUsoExpedienteConTramitesAsociados CUEConTramitesAsociados =
            new CasoDeUsoExpedienteConTramitesAsociados(repoExpediente, repoTramite);

        CasoDeUsoTramiteAlta CUTAlta = new CasoDeUsoTramiteAlta(
            repoTramite,
            servicioAutorizacion,
            servActEstado
        );
        CasoDeUsoTramiteBaja CUTBaja = new CasoDeUsoTramiteBaja(
            repoTramite,
            servicioAutorizacion,
            servActEstado
        );
        CasoDeUsoTramiteModificacion CUTModificacion = new CasoDeUsoTramiteModificacion(
            repoTramite,
            servicioAutorizacion,
            servActEstado
        );
        CasoDeUsoTramiteConsultaPorEtiqueta CUTConsultaPorEtiqueta =
            new CasoDeUsoTramiteConsultaPorEtiqueta(repoTramite);

        TestCambioEstados();
        //TestTramitesAsociados();
        //TestExpedienteConsultaTodos();
        //TestModificaciones();
        //TestConsultaTramitePorEtiqueta();
        //TestUsuarioSinPermisos();
        //TestEntidadesVacias();

        void TestCambioEstados()
        {
            Console.WriteLine("Test cambio de estados");

            CUEAlta.Ejecutar(new Expediente("Caratula Expediente 1"), 1);

            Expediente? expe = CUEConsultaPorId.Ejecutar(1);
            Console.WriteLine("Antes de agregar un trámite: ");
            Console.WriteLine(expe?.Estado);
            //Damos de alta tramites, y lo asociamos a los expedientes.
            Tramite t1 = new Tramite(1, EtiquetaTramite.Resolucion, "Contenidooooooo");
            Tramite t2 = new Tramite(1, EtiquetaTramite.PaseAEstudio, "Contenidooooooo");

            CUTAlta.Ejecutar(t1, 1);

            expe = CUEConsultaPorId.Ejecutar(1);
            Console.WriteLine("Después de agregar un trámite: ");
            Console.WriteLine(expe?.Estado);

            CUTAlta.Ejecutar(t2, 1);

            expe = CUEConsultaPorId.Ejecutar(1);
            Console.WriteLine("Después de agregar otro trámite: ");
            Console.WriteLine(expe?.Estado);

            CUTBaja.Ejecutar(2, 1);

            expe = CUEConsultaPorId.Ejecutar(1);
            Console.WriteLine("Después de eliminar el último trámite: ");
            Console.WriteLine(expe?.Estado);

            t1.IdTramite = 1;
            t1.TipoTramite = EtiquetaTramite.PaseAEstudio;

            CUTModificacion.Ejecutar(t1, 1);
            expe = CUEConsultaPorId.Ejecutar(1);
            Console.WriteLine("Después de modificar el trámite restante: ");
            Console.WriteLine(expe?.Estado);
        }

        void TestTramitesAsociados()
        {
            CUEAlta.Ejecutar(new Expediente("Caratula Expediente 1"), 1);

            Tramite t1 = new Tramite(1, EtiquetaTramite.Resolucion, "Contenidooooooo");
            Tramite t2 = new Tramite(1, EtiquetaTramite.PaseAEstudio, "Contenidooooooo");
            CUTAlta.Ejecutar(t1, 1);
            CUTAlta.Ejecutar(t1, 1);
            CUTAlta.Ejecutar(t1, 1);
            CUTAlta.Ejecutar(t2, 1);
            CUTAlta.Ejecutar(t2, 1);
            CUTAlta.Ejecutar(t2, 1);

            Expediente? e = CUEConTramitesAsociados.Ejecutar(1);
            if (e?.listaDeTramites != null)
            {
                foreach (Tramite t in e.listaDeTramites)
                {
                    Console.WriteLine(t.ToString());
                }
            }
        }

        void TestExpedienteConsultaTodos()
        {
            CUEAlta.Ejecutar(new Expediente("Caratula Expediente 1"), 1);
            CUEAlta.Ejecutar(new Expediente("Caratula Expediente 1"), 1);
            CUEAlta.Ejecutar(new Expediente("Caratula Expediente 1"), 1);
            List<Expediente> listaExpedientes = CUEConsultaTodos.Ejecutar();
            Console.WriteLine(listaExpedientes.Count());
        }

        void TestModificaciones()
        {
            Expediente e1 = new Expediente("Caratula Expediente 1");
            CUEAlta.Ejecutar(e1, 1);
            Console.WriteLine(e1.Caratula);

            e1.Caratula = "ñasdlkjf";
            CUEModificacion.Ejecutar(e1, 1);
            Expediente? e2 = CUEConsultaPorId.Ejecutar(1);
            Console.WriteLine(e2?.Caratula);
        }

        void TestConsultaTramitePorEtiqueta()
        {
            CUEAlta.Ejecutar(new Expediente("Caratula Expediente 1"), 1);
            CUTAlta.Ejecutar(new Tramite(1, EtiquetaTramite.Resolucion, "Contenidooooooo"), 1);
            CUTAlta.Ejecutar(new Tramite(1, EtiquetaTramite.PaseAEstudio, "Contenidooooooo"), 1);
            CUTAlta.Ejecutar(new Tramite(1, EtiquetaTramite.Despacho, "Contenidooooooo"), 1);
            CUTAlta.Ejecutar(new Tramite(1, EtiquetaTramite.PaseAlArchivo, "Contenidooooooo"), 1);
            CUTAlta.Ejecutar(new Tramite(1, EtiquetaTramite.PaseAlArchivo, "Contenidooooooo"), 1);
            CUTAlta.Ejecutar(new Tramite(1, EtiquetaTramite.PaseAlArchivo, "Contenidooooooo"), 1);
            CUTAlta.Ejecutar(new Tramite(1, EtiquetaTramite.Notificacion, "Contenidooooooo"), 1);
            CUTAlta.Ejecutar(
                new Tramite(1, EtiquetaTramite.EscritoPresentado, "Contenidooooooo"),
                1
            );
            CUTAlta.Ejecutar(
                new Tramite(1, EtiquetaTramite.EscritoPresentado, "Contenidooooooo"),
                1
            );
            CUTAlta.Ejecutar(new Tramite(1, EtiquetaTramite.Resolucion, "Contenidooooooo"), 1);
            CUTAlta.Ejecutar(new Tramite(1, EtiquetaTramite.Resolucion, "Contenidooooooo"), 1);

            List<Tramite> l1 = CUTConsultaPorEtiqueta.Ejecutar(EtiquetaTramite.EscritoPresentado);
            List<Tramite> l2 = CUTConsultaPorEtiqueta.Ejecutar(EtiquetaTramite.PaseAlArchivo);
            Console.WriteLine(l1.Count);
            Console.WriteLine(l2.Count);
        }

        void TestUsuarioSinPermisos()
        {
            CUEAlta.Ejecutar(new Expediente("Caratula Expediente 1"), 1);
            CUEAlta.Ejecutar(new Expediente("Caratula Expediente 1"), 1);
            CUEAlta.Ejecutar(new Expediente("Caratula Expediente 1"), 2); // id Diferente a 1
            List<Expediente> listaExpedientes = CUEConsultaTodos.Ejecutar();
            Console.WriteLine(listaExpedientes.Count());
        }

        void TestEntidadesVacias()
        {
            CUEAlta.Ejecutar(new Expediente("Caratula Expediente 1"), 1);
            CUEAlta.Ejecutar(new Expediente(), 1);
            List<Expediente> listaExpedientes = CUEConsultaTodos.Ejecutar();
            Console.WriteLine(listaExpedientes.Count());

            CUTAlta.Ejecutar(new Tramite(1, EtiquetaTramite.Resolucion, "Contenidooooooo"), 1);
            CUTAlta.Ejecutar(new Tramite(), 1);
        }
    }
}

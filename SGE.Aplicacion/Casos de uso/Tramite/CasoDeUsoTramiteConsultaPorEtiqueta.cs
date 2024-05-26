namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repoTramite)
{

    public List<Tramite> Ejecutar(EtiquetaTramite e){
       return repoTramite.TramiteConsultaPorEtiqueta(e);
    }
}

namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void TramiteAlta(Tramite t);
    void TramiteBaja(int idTramite); 
    void TramiteModificacion(Tramite t);
    List<Tramite> TramiteConsultaPorEtiqueta(EtiquetaTramite e);
    List<Tramite> TramiteConsultaPorIdExpediente(int IdExpediente);
    Tramite TramiteConsultaUltimo();
    void eliminarTramitesAsociados(int idExpediente);
}

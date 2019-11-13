namespace GrupoAOX.Estagio.Application.Interfaces
{
    public interface IDashboardAppServices
    {
        int ObterLotesIntegrados();
        int ObterLotesAguardandoIntegracao();
        int ObterLotesFalhaIntegracao();
    }
}

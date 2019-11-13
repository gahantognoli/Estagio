namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface IDashboardRepositorio
    {
        int ObterLotesIntegrados();
        int ObterLotesAguardandoIntegracao();
        int ObterLotesFalhaIntegracao();
    }
}

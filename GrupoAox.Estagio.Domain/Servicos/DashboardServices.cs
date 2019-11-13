using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;

namespace GrupoAox.Estagio.Domain.Servicos
{
    public class DashboardServices : IDashboardServices
    {
        private readonly IDashboardRepositorio _dashboardRepositorio;

        public DashboardServices(IDashboardRepositorio dashboardRepositorio)
        {
            _dashboardRepositorio = dashboardRepositorio;
        }

        public int ObterLotesAguardandoIntegracao()
        {
            return _dashboardRepositorio.ObterLotesAguardandoIntegracao();
        }

        public int ObterLotesFalhaIntegracao()
        {
            return _dashboardRepositorio.ObterLotesFalhaIntegracao();
        }

        public int ObterLotesIntegrados()
        {
            return _dashboardRepositorio.ObterLotesIntegrados();
        }
    }
}

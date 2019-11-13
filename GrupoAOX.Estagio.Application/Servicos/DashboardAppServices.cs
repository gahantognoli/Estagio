using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAOX.Estagio.Application.Interfaces;

namespace GrupoAOX.Estagio.Application.Servicos
{
    public class DashboardAppServices : IDashboardAppServices
    {
        private readonly IDashboardServices _dashboardServices;

        public DashboardAppServices(IDashboardServices dashboardServices)
        {
            _dashboardServices = dashboardServices;
        }

        public int ObterLotesAguardandoIntegracao()
        {
            return _dashboardServices.ObterLotesAguardandoIntegracao();
        }

        public int ObterLotesFalhaIntegracao()
        {
            return _dashboardServices.ObterLotesFalhaIntegracao();
        }

        public int ObterLotesIntegrados()
        {
            return _dashboardServices.ObterLotesIntegrados();
        }
    }
}

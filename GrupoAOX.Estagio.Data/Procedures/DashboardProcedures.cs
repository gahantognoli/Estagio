using System.ComponentModel;

namespace GrupoAOX.Estagio.Data.Procedures
{
    public enum DashboardProcedures
    {
        [Description("usp_Dashboard_ObterLotesIntegrados")]
        ObterIntegrados,
        [Description("usp_Dashboard_ObterLotesAguardandoIntegracao")]
        ObterAguardandoIntegracao,
        [Description("usp_Dashboard_ObterLotesFalhaIntegracao")]
        ObterFalhaIntegracao
    }
}

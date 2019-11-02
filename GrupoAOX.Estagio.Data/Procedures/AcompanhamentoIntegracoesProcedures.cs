using System.ComponentModel;

namespace GrupoAOX.Estagio.Data.Procedures
{
    public enum AcompanhamentoIntegracoesProcedures
    {
        [Description("usp_Lotes_AcompanhamentoIntegracoes")]
        ObterTodos,
        [Description("usp_Lotes_AcompanhamentoIntegracoes_PorData")]
        ObterPorData,
        [Description("usp_Lotes_AcompanhamentoIntegracoes_PorDocumento")]
        ObterPorDocumento,
        [Description("usp_Lotes_AcompanhamentoIntegracoes_PorLote")]
        ObterPorLote
    }
}

using System.ComponentModel;

namespace GrupoAOX.Estagio.Data.Procedures
{
    public enum PermissaoProcedures
    {
        [Description("usp_Permissoes_ObterTodos")]
        ObterTodos,
        [Description("usp_Permissao_ObterPorDescricao")]
        ObterPorDescricao,
        [Description("usp_Permissao_ObterPorSigla")]
        ObterPorSigla,
        [Description("usp_Permissoes_ObterPorId")]
        ObterPorId
    }
}

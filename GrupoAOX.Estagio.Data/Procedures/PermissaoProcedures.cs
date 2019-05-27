using System.ComponentModel;

namespace GrupoAOX.Estagio.Data.Procedures
{
    public enum PermissaoProcedures
    {
        [Description("usp_Permissoes_ObterTodos")]
        ObterTodos,
        [Description("usp_Permissoes_ObterPorId")]
        ObterPorId
    }
}

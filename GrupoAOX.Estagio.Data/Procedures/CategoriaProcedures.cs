using System.ComponentModel;

namespace GrupoAOX.Estagio.Data.Procedures
{
    public enum CategoriaProcedures
    {
        [Description("usp_Categoria_ObterPorTodos")]
        ObterTodos,
        [Description("usp_Categoria_ObterPorDescricao")]
        ObterPorDescricao,
        [Description("usp_Categoria_ObterPorId")]
        ObterPorId
    }
}

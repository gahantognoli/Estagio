using System.ComponentModel;

namespace GrupoAOX.Estagio.Data.Procedures
{
    public enum StatusProcedures
    {
        [Description("usp_Status_ObterPorDescricao")]
        ObterPorDescricao,
        [Description("usp_Status_ObterTodos")]
        ObterTodos,
        [Description("usp_Status_ObterPorId")]
        ObterPorId
    }
}

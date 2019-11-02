using System.ComponentModel;

namespace GrupoAOX.Estagio.Data.Procedures
{
    public enum LembretesProcedures
    {
        [Description("usp_Lembrete_ObterPorDataLancamento")]
        ObterPorDataLancamento,
        [Description("usp_Lembrete_ObterPorId")]
        ObterPorId,
        [Description("usp_Lembrete_ObterTodos")]
        ObterTodos
    }
}

using System.ComponentModel;

namespace GrupoAOX.Estagio.Data.Procedures
{
    public enum LoteProcedures
    {
        [Description("usp_Lotes_ObterTodos")]
        ObterTodos,
        [Description("usp_Lotes_ObterPorId")]
        ObterPorId,
        [Description("usp_Lotes_ObterPorDocumento")]
        ObterPorDocumento,
        [Description("usp_Lotes_ObterPorLote")]
        ObterPorLote
    }
}

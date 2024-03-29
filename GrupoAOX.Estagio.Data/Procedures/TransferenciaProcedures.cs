﻿using System.ComponentModel;

namespace GrupoAOX.Estagio.Data.Procedures
{
    public enum TransferenciaProcedures
    {
        [Description("usp_Transferencias_ObterPorId")]
        ObterPorId,
        [Description("usp_Transferencias_ObterTodos")]
        ObterTodos,
        [Description("usp_Transferencias_ObterTodosPorCategoria")]
        ObterTodosPorCategoria,
        [Description("usp_Transferencias_ObterPorPeriodo")]
        ObterPorPeriodo,
        [Description("usp_Transferencias_ObterNumDocumento")]
        ObterNumeroDocumento,
        [Description("usp_Transferencias_ObterPorNumDocumento")]
        ObterPorNumDocumento,
        [Description("usp_Transferencias_ObterPorData")]
        ObterPorData,
        [Description("usp_Transferencias_ObterPorUsuario")]
        ObterPorUsuario
    }
}

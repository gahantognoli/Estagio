using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAOX.Estagio.Data.Procedures
{
    public enum LogLotesProcedures
    {
        [Description("usp_LogLotes_ObterTodos")]
        ObterTodos,
        [Description("usp_LogLotes_ObterPorPeriodo")]
        ObterPorPeriodo,
        [Description("usp_LogLotes_ObterPorUsuario")]
        ObterPorUsuario
    }
}

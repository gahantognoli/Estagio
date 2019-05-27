using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAOX.Estagio.Data.Procedures
{
    public enum StatusProcedures
    {
        [Description("usp_Status_ObterTodos")]
        ObterTodos,
        [Description("usp_Status_ObterPorId")]
        ObterPorId
    }
}

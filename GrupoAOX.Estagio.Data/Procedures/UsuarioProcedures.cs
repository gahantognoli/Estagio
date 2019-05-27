using System.ComponentModel;

namespace GrupoAOX.Estagio.Data.Procedures
{
    public enum UsuarioProcedures
    {
        [Description("usp_Usuarios_ObterTodos")]
        ObterTodos,
        [Description("usp_Usuarios_ObterPorId")]
        ObterPorId
    }
}

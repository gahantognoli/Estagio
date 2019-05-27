using System.Configuration;

namespace GrupoAOX.Estagio.Data.Procedures
{
    public static class ConexaoBancoDeDados
    {
        public static string ObterStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["PWProlinhas"].ConnectionString;
        }
    }
}

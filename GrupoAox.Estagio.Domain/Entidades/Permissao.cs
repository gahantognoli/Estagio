using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAox.Estagio.Domain.Entidades
{
    public class Permissao
    {
        public int PermissaoId { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}

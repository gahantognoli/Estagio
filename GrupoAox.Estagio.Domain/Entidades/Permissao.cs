using DomainValidation.Validation;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Entidades
{
    public class Permissao
    {
        public int PermissaoId { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public bool Deletado { get; set; } = false;

        public ValidationResult ValidationResult { get; set; }
    }
}

using DomainValidation.Validation;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }
        public string CaminhoImg { get; set; }
        public virtual ICollection<Permissao> Permissoes { get; set; }
        public virtual ICollection<Transferencia> Transferencias { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}

using DomainValidation.Validation;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Entidades
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        public ICollection<Transferencia> Transferencias { get; set; }
        public bool Deletado { get; set; } = false;

        public ValidationResult ValidationResult { get; set; }
    }
}

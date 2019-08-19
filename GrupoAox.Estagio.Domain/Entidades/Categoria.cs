using DomainValidation.Validation;
using GrupoAox.Estagio.Domain.Enums;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Entidades
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        public TipoCategoria TipoCategoria { get; set; }

        public ICollection<Transferencia> Transferencias { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}

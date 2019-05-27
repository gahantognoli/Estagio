using DomainValidation.Validation;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Entidades
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Descricao { get; set; }
        public ICollection<int_exp_Etiqueta_Producao> Lotes { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}

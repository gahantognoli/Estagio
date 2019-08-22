using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoAOX.Estagio.Application.ViewModel
{
    public class StatusViewModel
    {
        [Display(Name = "Id")]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(50, ErrorMessage = "Descrição deve possuir no máximo 50 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public ICollection<int_exp_Etiqueta_ProducaoViewModel> Lotes { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}

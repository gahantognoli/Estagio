using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoAOX.Estagio.Application.ViewModel
{
    public class StatusViewModel
    {
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Preencha a descrição do status")]
        [MaxLength(50, ErrorMessage = "Descrição deve possuir no máximo 50 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public ICollection<int_exp_Etiqueta_ProducaoViewModel> Lotes { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}

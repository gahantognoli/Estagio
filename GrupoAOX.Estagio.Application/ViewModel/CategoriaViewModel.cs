using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoAOX.Estagio.Application.ViewModel
{
    public class CategoriaViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Preencha a descrição da categoria")]
        [MaxLength(50, ErrorMessage = "Descrição deve possuir no máximo 50 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Tipo Categoria")]
        public ICollection<TransferenciaViewModel> Transferencias { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}

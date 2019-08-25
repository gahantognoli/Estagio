using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoAOX.Estagio.Application.ViewModel
{
    public class PermissaoViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public int PermissaoId { get; set; }

        [Required(ErrorMessage = "Preencha a sigla da permissão")]
        [MaxLength(5, ErrorMessage = "Sigla deve possuir no máximo 5 caracteres")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "Preencha a descrição da permissão")]
        [MaxLength(100, ErrorMessage = "Descrição deve possuir no máximo 100 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<UsuarioViewModel> Usuarios { get; set; }

        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}

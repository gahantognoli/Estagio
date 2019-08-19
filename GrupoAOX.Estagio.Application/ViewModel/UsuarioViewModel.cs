using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoAOX.Estagio.Application.ViewModel
{
    public class UsuarioViewModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Preencha o login do usuário")]
        [MaxLength(50, ErrorMessage = "Login deve possuir no máximo 50 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Preencha o nome do usuário")]
        [MaxLength(100, ErrorMessage = "Nome deve possuir no máximo 100 caracteres")]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Preencha o email do usuário")]
        [MaxLength(100, ErrorMessage = "Email deve possuir no máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um e-mail válido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public string CaminhoImg { get; set; }
        public ICollection<PermissaoViewModel> Permissoes { get; set; }
        public ICollection<TransferenciaViewModel> Transferencias { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}

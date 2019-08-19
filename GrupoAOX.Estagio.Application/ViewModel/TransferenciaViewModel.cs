using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAOX.Estagio.Application.ViewModel
{
    public class TransferenciaViewModel
    {
        [Key]
        public int TransferenciaId { get; set; }

        [Display(Name = "Data Movimento")]
        [ScaffoldColumn(false)]
        public DateTime DataMovimento { get; set; }

        [Display(Name = "Armazém Origem")]
        [ScaffoldColumn(false)]
        public string ArmazemOrigem { get; set; }

        [Required(ErrorMessage = "Informe o armazém destino da transferência")]
        [StringLength(2, ErrorMessage = "Armazém de destino deve possuir 2 caracteres")]
        [Display(Name = "Armazém Destino")]
        public string ArmazemDestino { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Número Documento")]
        public string NumeroDocumento { get; set; }

        [ScaffoldColumn(false)]
        public int CategoriaId { get; set; }
        public int UsuarioId { get; set; }
        [ScaffoldColumn(false)]

        public ICollection<int_exp_Etiqueta_ProducaoViewModel> Lotes { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public CategoriaViewModel Categoria { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoAOX.Estagio.Application.ViewModel
{
    public class LembreteViewModel
    {
        public int LembreteId { get; set; }

        [Display(Name = "Lembrete")]
        [Required(ErrorMessage = "Informe o lembrete")]
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; } = DateTime.Now;
        public bool Concluido { get; set; } = false;
        public bool Deletado { get; set; } = false;
        public int UsuarioId { get; set; }
        public int TransferenciaId { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }
        public virtual TransferenciaViewModel Transferencia { get; set; }
    }
}

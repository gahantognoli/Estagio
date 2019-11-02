using System;

namespace GrupoAOX.Estagio.Application.ViewModel
{
    public class LembreteViewModel
    {
        public int LembreteId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public bool Concluido { get; set; } = false;
        public int UsuarioId { get; set; }
        public int TransferenciaId { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }
        public virtual TransferenciaViewModel Transferencia { get; set; }
    }
}

using System;

namespace GrupoAox.Estagio.Domain.Entidades
{
    public class Lembrete
    {
        public int LembreteId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public bool Concluido { get; set; } = false;
        public bool Deletado { get; set; } = false;
        public int UsuarioId { get; set; }
        public int TransferenciaId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Transferencia Transferencia { get; set; }
        
    }
}

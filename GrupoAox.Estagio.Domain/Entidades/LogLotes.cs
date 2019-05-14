using System;

namespace GrupoAox.Estagio.Domain.Entidades
{
    public class LogLotes
    {
        public int LogLoteId { get; set; }
        public string Usuario { get; set; }
        public DateTime Data { get; set; }
        public int ApontamentoProducaoId { get; set; }

        public int_exp_Etiqueta_Producao Lote { get; set; }
    }
}

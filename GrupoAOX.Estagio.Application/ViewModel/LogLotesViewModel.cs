using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoAOX.Estagio.Application.ViewModel
{
    public class LogLotesViewModel
    {
        public int LogLoteId { get; set; }
        public string Usuario { get; set; }
        public DateTime Data { get; set; }
        public string OrdemProducao { get; set; }
        public string Etiqueta { get; set; }
        public string Armazem { get; set; }
        public string NumDocumento { get; set; }
        public string Acao { get; set; }
        public int ApontamentoProducaoId { get; set; }

        public int_exp_Etiqueta_ProducaoViewModel Lote { get; set; }
    }
}

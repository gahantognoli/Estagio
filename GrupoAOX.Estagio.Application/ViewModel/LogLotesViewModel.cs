using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoAOX.Estagio.Application.ViewModel
{
    public class LogLotesViewModel
    {
        [Display(Name = "Id")]
        public int LogLoteId { get; set; }

        [Display(Name = "Usuário")]
        public string Usuario { get; set; }

        [Display(Name = "Data Modificação")]
        public DateTime Data { get; set; }

        [Display(Name = "Lote Id")]
        public int ApontamentoProducaoId { get; set; }

        public int_exp_Etiqueta_ProducaoViewModel Lote { get; set; }
    }
}

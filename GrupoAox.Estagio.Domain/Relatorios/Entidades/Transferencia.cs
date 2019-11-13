using System;

namespace GrupoAox.Estagio.Domain.Relatorios.Entidades
{
    public class Transferencia
    {
        public int TransferenciaId { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime DataMovimento { get; set; }
        public string ArmazemDestino { get; set; }
        public string Etiqueta { get; set; }
        public DateTime DataLancamento { get; set; }
        public string OrderProducao { get; set; }
        public string Produto { get; set; }
        public decimal QtdM2 { get; set; }
        public decimal QtdMetroLinear { get; set; }
        public string Categoria { get; set; }
        public string NumDocumento { get; set; }
        public string Status { get; set; }
        public string Usuario { get; set; }
    }
}

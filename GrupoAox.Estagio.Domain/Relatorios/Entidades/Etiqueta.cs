using System;

namespace GrupoAox.Estagio.Domain.Relatorios.Entidades
{
    public class Etiqueta
    {
        public string OP { get; set; }
        public string NumEtiqueta { get; set; }
        public string Produto { get; set; }
        public decimal QtdProducao { get; set; }
        public decimal QtdMetrosLineares { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoLiquido { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Situacao { get; set; }
        public string Descartada { get; set; }
        public string IlhaImpressao { get; set; }
        public string LogIntegracao { get; set; }
    }
}

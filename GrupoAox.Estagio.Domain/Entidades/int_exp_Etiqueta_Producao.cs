using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Entidades
{
    public class int_exp_Etiqueta_Producao
    {
        public int ApontamentoProducaoId { get; set; }
        public string OrderProducao { get; set; }
        public int TipoEmbalagem { get; set; }
        public string Etiqueta { get; set; }
        public decimal QuantidadeProducao { get; set; }
        public decimal QtdMetroLinear { get; set; }
        public decimal QuantidadePerda { get; set; }
        public int NumeroDefeitos { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoLiquido { get; set; }
        public string UsuarioId { get; set; }
        public int OperadorId { get; set; }
        public int LiderId { get; set; }
        public string Turma { get; set; }
        public DateTime DataLancamento { get; set; }
        public int StatusId { get; set; }
        public DateTime DataImportacao { get; set; }
        public string Filial { get; set; }
        public string Armazem { get; set; }
        public string Produto { get; set; }
        public decimal tempoProducao { get; set; }
        public int MaquinaId { get; set; }
        public string LogIntegracao { get; set; }
        public string DoctoProducao { get; set; }
        public int IlhaImpressao { get; set; }
        public string Romaneio { get; set; }
        public string TipoDocumento { get; set; }
        public string MaquinaDesc { get; set; }
        public string Observacao { get; set; }
        public string LoteOrigem { get; set; }
        public bool UltimaBobina { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public Status Status { get; set; }
        public ICollection<LogLotes> LogLotes { get; set; }
    }
}

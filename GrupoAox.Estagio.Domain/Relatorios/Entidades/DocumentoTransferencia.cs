namespace GrupoAox.Estagio.Domain.Relatorios.Entidades
{
    public class DocumentoTransferencia
    {
        public string NumDocumento { get; set; }
        public string Armazem { get; set; }
        public string Palete { get; set; }
        public string OP { get; set; }
        public string Produto { get; set; }
        public decimal PesoLiquido { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal QuantidadeM2 { get; set; }
        public decimal QuantidadeMT { get; set; }
        public string Local { get; set; }
        public string Observacao { get; set; }
    }
}

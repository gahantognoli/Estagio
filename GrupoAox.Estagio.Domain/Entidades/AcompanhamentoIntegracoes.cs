namespace GrupoAox.Estagio.Domain.Entidades
{
    public class AcompanhamentoIntegracoes
    {
        public int Id { get; set; }
        public string Lote { get; set; }
        public string Documento { get; set; }
        public string DataLancamento { get; set; }
        public string Armazem { get; set; }
        public string Status { get; set; }
        public string LogIntegracao { get; set; }
    }
}

using System;

namespace GrupoAox.Estagio.Domain.Relatorios.Entidades
{
    public class Movimento
    {
        public DateTime DataMovimento { get; set; }
        public string ArmazemDestino { get; set; }
        public string NumeroDocumento { get; set; }
        public string Usuario { get; set; }
        public string Lote { get; set; }
    }
}

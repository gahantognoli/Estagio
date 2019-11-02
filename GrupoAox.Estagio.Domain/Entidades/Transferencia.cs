using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Entidades
{
    public class Transferencia
    {
        public int TransferenciaId { get; set; }
        public DateTime DataMovimento { get; set; }
        public string ArmazemOrigem { get; set; }
        public string ArmazemDestino { get; set; }
        public string NumeroDocumento { get; set; }
        public int CategoriaId { get; set; }
        public int UsuarioId { get; set; }
        public ICollection<int_exp_Etiqueta_Producao> Lotes { get; set; }
        public ICollection<Lembrete> Lembretes { get; set; }
        public Usuario Usuario { get; set; }
        public Categoria Categoria { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}

﻿using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }
        public string CaminhoImg { get; set; }
        public ICollection<Permissao> Permissoes { get; set; }
        public ICollection<Transferencia> Transferencias { get; set; }
    }
}

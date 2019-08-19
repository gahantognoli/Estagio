﻿using GrupoAox.Estagio.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrupoAOX.Estagio.Application.ViewModel
{
    public class CategoriaViewModel
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Preencha a descrição da categoria")]
        [MaxLength(50, ErrorMessage = "Descrição deve possuir no máximo 50 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public TipoCategoria TipoCategoria { get; set; }

        public ICollection<TransferenciaViewModel> Transferencias { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
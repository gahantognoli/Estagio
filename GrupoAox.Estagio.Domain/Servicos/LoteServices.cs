using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAox.Estagio.Domain.Validations.Lotes;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Servicos
{
    public class LoteServices : ILoteServices
    {
        private readonly ILoteRepositorio _loteRepositorio;

        public LoteServices(ILoteRepositorio loteRepositorio)
        {
            _loteRepositorio = loteRepositorio;
        }

        public int_exp_Etiqueta_Producao AtualizarStatus(int id, Status status)
        {
            return _loteRepositorio.AtualizarStatus(id, status);
        }

        public int_exp_Etiqueta_Producao BiparEtiqueta(string numLote)
        {
            int_exp_Etiqueta_Producao lote = ObterPorLote(numLote);
            lote.ValidationResult = new LoteAptoParaCadastroValidation().Validate(lote);
            return lote;
        }

        public void Dispose()
        {
            _loteRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public int_exp_Etiqueta_Producao ObterPorDocumento(string numDocumento)
        {
            return _loteRepositorio.ObterPorDocumento(numDocumento);
        }

        public int_exp_Etiqueta_Producao ObterPorId(int id)
        {
            return _loteRepositorio.ObterPorId(id);
        }

        public int_exp_Etiqueta_Producao ObterPorLote(string numLote)
        {
            return _loteRepositorio.ObterPorLote(numLote);
        }

        public IEnumerable<int_exp_Etiqueta_Producao> ObterTodos()
        {
            return _loteRepositorio.ObterTodos();
        }

        public int_exp_Etiqueta_Producao RegistrarRomaneio(int id, string romaneio, string tipoDocumento)
        {
            return _loteRepositorio.RegistrarRomaneio(id, romaneio, tipoDocumento);
        }
    }
}

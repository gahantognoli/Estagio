using GrupoAox.Estagio.Domain.Entidades;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface ILoteRepositorio : IRepositorio<int_exp_Etiqueta_Producao>
    {
        int_exp_Etiqueta_Producao AtualizarStatus(int id, int statusId);
        int_exp_Etiqueta_Producao ObterPorDocumento(string numDocumento);
        int_exp_Etiqueta_Producao ObterPorLote(string numLote);
        int_exp_Etiqueta_Producao Atualizar(int id, string armazem, int statusId, string romaneio, string tipoDocumento);
    }
}

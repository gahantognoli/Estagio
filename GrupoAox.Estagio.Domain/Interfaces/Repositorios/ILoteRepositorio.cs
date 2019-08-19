using GrupoAox.Estagio.Domain.Entidades;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface ILoteRepositorio : IRepositorio<int_exp_Etiqueta_Producao>
    {
        int_exp_Etiqueta_Producao RegistrarRomaneio(int id, string numRomaneio, string tipoDocumento);
        int_exp_Etiqueta_Producao AtualizarStatus(int id, Status status);
        int_exp_Etiqueta_Producao ObterPorDocumento(string numDocumento);
        int_exp_Etiqueta_Producao ObterPorLote(string numLote);
        int_exp_Etiqueta_Producao AtualizarArmazem(int id, string armazem);
    }
}

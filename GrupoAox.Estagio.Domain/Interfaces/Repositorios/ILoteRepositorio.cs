using GrupoAox.Estagio.Domain.Entidades;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface ILoteRepositorio : IRepositorio<int_exp_Etiqueta_Producao>
    {
        int_exp_Etiqueta_Producao RegistrarRomaneio(string numRomaneio, string tipoDocumento);
        int_exp_Etiqueta_Producao AtualizarStatus();
        int_exp_Etiqueta_Producao ObterPorDocumento(string numDocumento);
        int_exp_Etiqueta_Producao ObterPorLote(string numLote);
    }
}

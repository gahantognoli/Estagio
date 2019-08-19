using GrupoAOX.Estagio.Application.ViewModel;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Interfaces
{
    public interface ILoteAppServices
    {
        IEnumerable<int_exp_Etiqueta_ProducaoViewModel> ObterTodos();
        int_exp_Etiqueta_ProducaoViewModel ObterPorId(int id);
        int_exp_Etiqueta_ProducaoViewModel ObterPorDocumento(string numDocumento);
        int_exp_Etiqueta_ProducaoViewModel ObterPorLote(string numLote);
        int_exp_Etiqueta_ProducaoViewModel RegistrarRomaneio(int id, string romaneio, string tipoDocumento);
        int_exp_Etiqueta_ProducaoViewModel AtualizarStatus(int id, StatusViewModel status);
        int_exp_Etiqueta_ProducaoViewModel BiparEtiqueta(string numLote);
        int_exp_Etiqueta_ProducaoViewModel AtualizarArmazem(int id, string armazem);
    }
}

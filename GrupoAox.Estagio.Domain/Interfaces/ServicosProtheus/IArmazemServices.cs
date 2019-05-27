using GrupoAox.Estagio.Domain.EntidadesProtheus;

namespace GrupoAox.Estagio.Domain.Interfaces.ServicosProtheus
{
    public interface IArmazemServices
    {
        Armazem ObterPorCodigo(string codigo);
    }
}

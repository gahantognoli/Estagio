using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAox.Estagio.Domain.Interfaces.Servicos
{
    public interface IDashboardServices
    {
        int ObterLotesIntegrados();
        int ObterLotesAguardandoIntegracao();
        int ObterLotesFalhaIntegracao();
    }
}

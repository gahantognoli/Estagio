using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.ViewModel
{
    public class UsuarioPermissaoViewModel
    {
        public UsuarioViewModel UsuarioViewModel { get; set; }
        public ICollection<PermissaoViewModel> PermissaoViewModel { get; set; }
    }
}

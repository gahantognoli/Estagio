using DomainValidation.Interfaces.Specification;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;

namespace GrupoAox.Estagio.Domain.Specifications.Usuarios
{
    public class UsuarioDevePossuirLoginUnicoSpecification : ISpecification<Usuario>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioDevePossuirLoginUnicoSpecification(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public bool IsSatisfiedBy(Usuario usuario)
        {
            return _usuarioRepositorio.ObterPorLogin(usuario.Login) == null;
        }
    }
}

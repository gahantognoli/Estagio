using AutoMapper;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using GrupoAOX.Estagio.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoAOX.Estagio.Application.Servicos
{
    public class UsuarioAppService : AppService, IUsuarioAppServices
    {
        private readonly IUsuarioServices _usuarioServices;
        private readonly IEntitySerializationServices<UsuarioViewModel> _entitySerializationServices;

        public UsuarioAppService(IUsuarioServices usuarioServices,
            IEntitySerializationServices<UsuarioViewModel> entitySerializationServices, IUnitOfWork uow) : base(uow)
        {
            _usuarioServices = usuarioServices;
            _entitySerializationServices = entitySerializationServices;
        }

        public UsuarioViewModel Adicionar(UsuarioViewModel usuario)
        {
            var usuarioRetorno = Mapper.Map<UsuarioViewModel>(_usuarioServices.Adicionar(Mapper.Map<Usuario>(usuario)));
            if (usuarioRetorno.ValidationResult.IsValid)
            {
                Commit();
            }
            return usuarioRetorno;
        }

        public UsuarioViewModel Alterar(UsuarioViewModel usuario)
        {
            var usuarioRetorno = Mapper.Map<UsuarioViewModel>(_usuarioServices.Alterar(Mapper.Map<Usuario>(usuario)));
            Commit();
            return usuarioRetorno;
        }

        public UsuarioPermissaoViewModel AtribuirPermissoes(UsuarioPermissaoViewModel usuarioPermissaoViewModel)
        {
            var usuario = Mapper.Map<Usuario>(usuarioPermissaoViewModel.UsuarioViewModel);

            foreach (var permissaoViewModel in usuarioPermissaoViewModel.PermissaoViewModel)
            {
                var permissao = Mapper.Map<Permissao>(permissaoViewModel);
                usuario.Permissoes.Add(permissao);
            }

            var usuarioRetorno = _usuarioServices.Adicionar(usuario);

            if (usuarioRetorno.ValidationResult.IsValid)
            {
                Commit();
            }

            return Mapper.Map<UsuarioPermissaoViewModel>(usuarioRetorno);
        }

        public void Dispose()
        {
            _usuarioServices.Dispose();
            GC.SuppressFinalize(this);
        }

        public UsuarioViewModel ImportarAD(string usuarioAD)
        {
            var usuarioADReturn = _usuarioServices.Adicionar(Mapper.Map<Usuario>(_entitySerializationServices.Deserialize(usuarioAD)));
            Commit();
            return Mapper.Map<UsuarioViewModel>(usuarioADReturn);
        }

        public UsuarioViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioServices.ObterPorEmail(email));
        }

        public UsuarioViewModel ObterPorId(int id)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioServices.ObterPorId(id));
        }

        public UsuarioViewModel ObterPorLogin(string login)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioServices.ObterPorLogin(login));
        }

        public IEnumerable<UsuarioViewModel> ObterPorNome(string nome)
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioServices.ObterPorNome(nome));
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioServices.ObterTodos());
        }

        public void Remover(int id)
        {
            _usuarioServices.Remover(id);
            Commit();
        }
    }
}

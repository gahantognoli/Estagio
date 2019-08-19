﻿using GrupoAOX.Estagio.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoAOX.Estagio.Application.Interfaces
{
    public interface IUsuarioAppServices
    {
        UsuarioViewModel Adicionar(UsuarioViewModel usuario);
        UsuarioPermissaoViewModel AtribuirPermissoes(UsuarioPermissaoViewModel usuarioPermissaoViewModel);
        Task<UsuarioViewModel> ImportarAD(string usuarioAD);
        UsuarioViewModel Alterar(UsuarioViewModel usuario);
        void Remover(int id);
        UsuarioViewModel ObterPorId(int id);
        IEnumerable<UsuarioViewModel> ObterTodos();
        UsuarioViewModel ObterPorLogin(string login);
        UsuarioViewModel ObterPorEmail(string email);
    }
}
using GrupoAOX.Estagio.Application.ViewModel;
using System;
using System.DirectoryServices.AccountManagement;

namespace GrupoAOX.Estagio.MVC.ActiveDirectory
{
    public static class ActiveDirectorySearch
    {
        public static UsuarioViewModel SearchUser(string busca = null)
        {
            ContextType authenticationType = ContextType.Domain;
            //ContextType authenticationType = ContextType.Machine;

            PrincipalContext principalContext = new PrincipalContext(authenticationType);
            UserPrincipal userPrincipal = new UserPrincipal(principalContext);
            userPrincipal.SamAccountName = busca;
            var searcher = new PrincipalSearcher(userPrincipal);

            try
            {
                userPrincipal = searcher.FindOne() as UserPrincipal;
            }
            catch (Exception ex)
            {
                return null;
            }

            UsuarioViewModel usuarioViewModel = new UsuarioViewModel()
            {
                Nome = userPrincipal.Name,
                Login = userPrincipal.SamAccountName,
                Email = userPrincipal.EmailAddress
            };


            return usuarioViewModel;
        }
    }
}
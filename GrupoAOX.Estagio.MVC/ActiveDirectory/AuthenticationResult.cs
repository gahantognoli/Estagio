using System;

namespace GrupoAOX.Estagio.MVC.ActiveDirectory
{
    public class AuthenticationResult
    {
        public AuthenticationResult(string errorMessage = null)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; private set; }
        public bool IsSuccess => String.IsNullOrEmpty(ErrorMessage);
    }
}
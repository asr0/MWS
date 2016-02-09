#region

using System;
using MWS.Dominio.Scope;
using MWS.NucleoCompartilhado.Helpers;

#endregion

namespace MWS.Dominio.Entidades
{
    public class Usuario
    {
        protected Usuario()
        {

        }
        public Usuario(string email, string password, bool admin)
        {
            Email = email;
            Password = StringHelper.Encriptar(password);
            IsAdmin = admin;
        }

        public int Id { get; private set; }
        public String Email { get; private set; }
        public String Password { get; private set; }
        public Boolean IsAdmin { get; private set; }

        public void Registrar()
        {
            this.RegistrarUsuarioValido();
            
        }

        public void ConcederAdministrador()
        {
            IsAdmin = true;
        }

        public void RevogarAdministrador()
        {
            IsAdmin = false;
        }

        public void Autenticar(string email, string senha)
        {
            this.AutenticarUsuarioValido(email, senha);
        }
    }
}
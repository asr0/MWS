using System;
using MWS.NucleoCompartilhado.Helpers;

namespace MWS.Dominio.Entidades
{
  public  class Usuario
    {
        public Usuario( string email, string password, bool admin)
        {
            Email = email;
            Password =StringHelper.Encriptar(password);
            IsAdmin = admin;
        }

        public int Id { get;private set; }
        public String Email { get;private set; }
        public String Password { get;private set; }
        public Boolean IsAdmin { get; private set; }

    }
}

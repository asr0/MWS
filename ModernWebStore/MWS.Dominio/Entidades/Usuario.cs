using System;

namespace MWS.Dominio.Entidades
{
  public  class Usuario
    {
        public Usuario( string email, string password, bool admin)
        {
            Email = email;
            Password = password;
            Admin = admin;
        }

        public int Id { get;private set; }
        public String Email { get;private set; }
        public String Password { get;private set; }
        public Boolean Admin { get; private set; }

    }
}

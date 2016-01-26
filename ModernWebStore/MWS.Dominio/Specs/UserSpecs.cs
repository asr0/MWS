#region

using System;
using System.Linq.Expressions;
using MWS.Dominio.Entidades;
using MWS.NucleoCompartilhado.Helpers;

#endregion

namespace MWS.Dominio.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<Usuario, bool>> AutenticarUsuario(string email, string senha)
        {
            var senhaEncriptada = StringHelper.Encriptar((senha));
            return x => x.Email == email && x.Password == senhaEncriptada;
        }

        public static Expression<Func<Usuario, bool>> GetByEmail(string email)
        {
            return x => x.Email == email;
        }
    }
}
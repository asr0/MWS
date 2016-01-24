using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MWS.Dominio.Entidades;
using MWS.NucleoCompartilhado.Helpers;

namespace MWS.Dominio.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<Usuario, bool>> AutenticarUsuario(string email, string senha)
        {
            string senhaEncriptada = StringHelper.Encriptar((senha));
            return x => x.Email == email && x.Password == senhaEncriptada;
        }

        public static Expression<Func<Usuario, bool>> GetByEmail(string email)
        {
            return x => x.Email ==email;
        }

    }
}

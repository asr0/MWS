using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWS.Dominio.Entidades;
using MWS.NucleoCompartilhado.Validacao;

namespace MWS.Dominio.Scope
{
    public static class UsuarioScope
    {
        public static bool RegistarUsuarioValido(this Usuario usuario)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(usuario.Email, "O Email é obrigatório"),
                    AssertionConcern.AssertEmailIsValid(usuario.Email,"O Email é Invalido"),
                    AssertionConcern.AssertNotEmpty(usuario.Password, "A senha é Obrigatória")
                );

        }
    }
}

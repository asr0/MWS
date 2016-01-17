#region

using MWS.Dominio.Entidades;
using MWS.NucleoCompartilhado.Resources;
using MWS.NucleoCompartilhado.Validacao;

#endregion

namespace MWS.Dominio.Scope
{
    public static class UsuarioScope
    {
        public static bool RegistrarUsuarioValido(this Usuario usuario)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(usuario.Email, Erros.EmailVazio),
                    AssertionConcern.AssertEmailIsValid(usuario.Email, Erros.EmailInvalido),
                    AssertionConcern.AssertNotEmpty(usuario.Password, Erros.SenhaVazio)
                );
        }

        public static bool AutenticarUsuarioValido(this Usuario usuario, string email, string senhaEncriptada)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(usuario.Email, Erros.EmailVazio),
                    AssertionConcern.AssertNotEmpty(usuario.Password, Erros.SenhaVazio),
                    AssertionConcern.AssertAreEquals(usuario.Email, email, "Usuario ou senha invalidos"),
                    AssertionConcern.AssertAreEquals(usuario.Password, senhaEncriptada, "Usuario ou senha Inválidos")
                );
        }
    }
}
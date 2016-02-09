using Microsoft.Owin.Security.OAuth;
using MWS.Dominio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MWS.Api.Security
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        IUsuarioApplicationService _usuarioService;
        public SimpleAuthorizationServerProvider(IUsuarioApplicationService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override  async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Acess-Control-Allow-Origin", new[] { "*" });
            var usuario = _usuarioService.Autenticar(context.UserName, context.Password);
            if (usuario == null)
            {
                
                context.SetError("invalid_grant", "Usuário ou senha Inválidos");
                return;
            }
                      

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Email));
            identity.AddClaim(new Claim(ClaimTypes.Role, usuario.IsAdmin ? "admin" : ""));

            GenericPrincipal principal = new GenericPrincipal(identity,new string[] { usuario.IsAdmin ? "admin" : "" });
            Thread.CurrentPrincipal = principal;
            context.Validated(identity);
        }
    }
}
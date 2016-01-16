using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MWS.Dominio.Entidades;
using MWS.Dominio.Scope;

namespace Dominio.Tests.Scopes
{
    [TestClass]
    public class UsuarioScopeTests
    {
        private Usuario _usuarioValido = new Usuario("contoso@contoso.com","123456",true);
        private Usuario _usuarioSenhaInvalida = new Usuario("contoso@contoso.com","",true);
        private Usuario _usuarioEmailInvalido = new Usuario("","13468",true);
        
        
        [TestMethod]
        [TestCategory("Usuario Scopes - Registrar")]
        public void Deve_Cadastrar_Usuario()
        {
          Assert.AreEqual(true,UsuarioScope.RegistrarUsuarioValido(_usuarioValido));
        }

        
    }
}

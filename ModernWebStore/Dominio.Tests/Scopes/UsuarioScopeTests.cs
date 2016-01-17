#region

using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MWS.Dominio.Entidades;
using MWS.Dominio.Scope;

#endregion

namespace Dominio.Tests.Scopes
{
    [TestClass]
    public class UsuarioScopeTests
    {
        private readonly Usuario _usuarioValido = new Usuario("contoso@contoso.com", "123456", true);
        private readonly Usuario _usuarioEmailInvalido = new Usuario("", "13468", true);
        private readonly Usuario _usuarioSenhaInvalida = new Usuario("contoso@contoso.com", "", true);

        [TestMethod]
        [TestCategory("Usuario Scopes - Registrar")]
        public void Deve_Cadastrar_Usuario()
        {
            Assert.AreEqual(true, UsuarioScope.RegistrarUsuarioValido(_usuarioValido));
        }

        [TestMethod]
        [TestCategory("Usuario Scopes - Registrar")]
        public void Nao_Deve_Cadastrar_Usuario_Sem_Email()
        {
            Assert.AreEqual(false, UsuarioScope.RegistrarUsuarioValido(_usuarioEmailInvalido));
        }

        [TestMethod]
        [TestCategory("Usuario Scopes - Registrar")]
        public void Nao_Deve_Cadastrar_Usuario_Sem_Senha()
        {
            Assert.AreEqual(false, UsuarioScope.RegistrarUsuarioValido(_usuarioSenhaInvalida));
        }


        [TestMethod]
        [TestCategory("Usuario Scopes - Autenticar")]
        public void Deve_Autenticar_Usuario()
        {   
            Assert.AreEqual(false, UsuarioScope.RegistrarUsuarioValido(_usuarioSenhaInvalida));
        }





    }
}
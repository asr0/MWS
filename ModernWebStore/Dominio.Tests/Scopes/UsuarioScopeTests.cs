﻿#region


using Microsoft.VisualStudio.TestTools.UnitTesting;
using MWS.Dominio.Entidades;
using MWS.Dominio.Scope;
using MWS.NucleoCompartilhado.Helpers;

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
        public void Deve_Autenticar_Usuario_Valido()
        {   
            Assert.AreEqual(true, UsuarioScope.AutenticarUsuarioValido(_usuarioValido, "contoso@contoso.com",StringHelper.Encriptar("123456")));
        }

        [TestMethod]
        [TestCategory("Usuario Scopes - Autenticar")]
        public void Nao_Deve_Autenticar_Usuario_Senha_Diferente()
        {
            Assert.AreEqual(false, UsuarioScope.AutenticarUsuarioValido(_usuarioValido, "contoso@contoso.com", StringHelper.Encriptar("123455")));
        }

        [TestMethod]
        [TestCategory("Usuario Scopes - Autenticar")]
        public void Nao_Deve_Autenticar_Usuario_Email_Diferente()
        {
            Assert.AreEqual(false, UsuarioScope.AutenticarUsuarioValido(_usuarioValido, "contoso@hotmail.com", StringHelper.Encriptar("123456")));
        }

        [TestMethod]
        [TestCategory("Usuario Scopes - Autenticar")]
        public void Nao_Deve_Autenticar_Usuario_Email_E_Senha_Diferente()
        {
            Assert.AreEqual(false, UsuarioScope.AutenticarUsuarioValido(_usuarioValido, "contoso@hotmail.com", StringHelper.Encriptar("123455")));
        }

    }
}
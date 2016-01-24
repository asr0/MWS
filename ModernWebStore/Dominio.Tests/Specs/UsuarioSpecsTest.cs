using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MWS.Dominio.Entidades;
using MWS.Dominio.Specs;
using MWS.NucleoCompartilhado.Helpers;

namespace Dominio.Tests.Specs
{
    [TestClass]
    public class UsuarioSpecsTest
    {
        private List<Usuario> _usuarios;

        public UsuarioSpecsTest()
        {
            _usuarios = new List<Usuario>();
            _usuarios.Add(new Usuario("contoso@contoso.com",StringHelper.Encriptar("123456"),true));
            _usuarios.Add(new Usuario("asro@mail.com", StringHelper.Encriptar("123"), true));
        }

        [TestMethod]
        [TestCategory("User Specs -  Autenticar")]
        public void Deve_Autenticar()
        {
            var exp = UserSpecs.AutenticarUsuario("contoso@contoso.com", StringHelper.Encriptar("123456"));
            var user = _usuarios.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null,user);
        }

        [TestMethod]
        [TestCategory("User Specs -  Autenticar")]
        public void Nao_Deve_Autenticar_Email_Errado()
        {
            var exp = UserSpecs.AutenticarUsuario("contoso2@contoso.com", StringHelper.Encriptar("123456"));
            var user = _usuarios.AsQueryable().Where(exp).FirstOrDefault();
            Assert.AreEqual(null, user);
        }


        [TestMethod]
        [TestCategory("User Specs -  Autenticar")]
        public void Nao_Deve_Autenticar_Senha_Errada()
        {
            var exp = UserSpecs.AutenticarUsuario("contoso@contoso.com", StringHelper.Encriptar("1234566"));
            var user = _usuarios.AsQueryable().Where(exp).FirstOrDefault();
            Assert.AreEqual(null, user);
        }


    }
}

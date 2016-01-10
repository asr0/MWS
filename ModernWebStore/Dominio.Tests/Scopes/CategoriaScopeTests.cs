using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MWS.Dominio.Entidades;
using MWS.Dominio.Scope;

namespace Dominio.Tests.Scopes
{
    /// <summary>
    /// Summary description for CategoriaScopeTests
    /// </summary>
    [TestClass]
    public class CategoriaScopeTests
    {

        [TestMethod]
        [TestCategory("Categoria")]
        public void DeveRegistarCategoria()
        {

            var categoria = new Categoria("Livro");
            Assert.AreEqual(true,CategoriaScope.CriacaoCategoriaValida(categoria));
        }
    }
}

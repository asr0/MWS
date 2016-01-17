#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MWS.Dominio.Entidades;
using MWS.Dominio.Scope;

#endregion

namespace Dominio.Tests.Scopes
{
    /// <summary>
    ///     Summary description for CategoriaScopeTests
    /// </summary>
    [TestClass]
    public class CategoriaScopeTests
    {
        [TestMethod]
        [TestCategory("Categoria")]
        public void DeveRegistarCategoria()
        {
            var categoria = new Categoria("Livro");
            Assert.AreEqual(true, categoria.CriacaoCategoriaValida());
        }
    }
}
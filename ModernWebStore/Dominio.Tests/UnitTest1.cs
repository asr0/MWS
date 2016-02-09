#region

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MWS.Dominio.Entidades;

#endregion

namespace Dominio.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var categoria = new Categoria("Placa mãe");
            var titulo = categoria.Titulo;
            var produto = new Produto("Titulo", "Descricao", 12.50m, 12, 1);
            var pedido = new Pedido(new List<ItemPedido>(), "sander@mail.com");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWS.Dominio.Entidades;
using MWS.NucleoCompartilhado.Validacao;

namespace MWS.Dominio.Scope
{
    public static class ItemPedidoScope
    {
        public static bool RegistarItemPedidoValido(this ItemPedido itemPedido)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertIsGreaterThan(itemPedido.Preco, 0, "Preço Invalido"),
                AssertionConcern.AssertIsGreaterThan(itemPedido.ProdutoId, 0, "Produto Invalido"),
                AssertionConcern.AssertIsGreaterThan(itemPedido.Quantidade, 0, "Quantidado Invalida")
                );
        }

        public static bool AdicionarItemProdutoValido(this ItemPedido itemPedido, Produto produto, int quantidade, decimal preco)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertIsGreaterOrEqualThan(produto.Quantidade - quantidade, 0, "Quantidade de produtos fora de estoque: "+produto.Titulo),
                AssertionConcern.AssertIsGreaterOrEqualThan(preco, 0, "O preco não pode ser menor que zero."),
                AssertionConcern.AssertIsGreaterThan(quantidade, 0, "A quantidade tem que ser maior que zero.")
                );
        }

    }
}

#region

using MWS.Dominio.Scope;

#endregion

namespace MWS.Dominio.Entidades
{
    public class ItemPedido
    {
        
        public int Id { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Preco { get; private set; }
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public Pedido Pedido { get; private set; }
        public int PedidoId { get; private set; }

        public bool Registrar()
        {
            return this.RegistarItemPedidoValido();
        }

        public void AdicionarProduto(Produto produto, int quantidade, decimal preco)
        {
            if (!this.AdicionarItemProdutoValido(produto, quantidade, preco))
                return;

            ProdutoId = produto.Id;
            Produto = produto;
            Quantidade = quantidade;
            Preco = preco;
            Produto.AtualizarQuantidade(Produto.Quantidade - quantidade);
        }
    }
}
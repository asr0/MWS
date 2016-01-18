using MWS.Dominio.Scope;

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
            if (!this.AdicionarItemProdutoValido(produto,quantidade, preco))
                return;

            this.ProdutoId = produto.Id;
            this.Produto = produto;
            this.Quantidade = quantidade;
            this.Preco = preco;
            this.Produto.AtualizarQuantidade(this.Produto.Quantidade - quantidade);
        }


    
}
}
#region

using System.Collections.Generic;
using MWS.Dominio.Entidades;
using MWS.Dominio.Repository;
using MWS.Dominio.Services;
using MWS.Infraestrutura.ORM;

#endregion

namespace MWS.Aplicacao
{
    public class PedidoApplicationService : ApplicationServiceBase, IPedidoApplicationService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public PedidoApplicationService(IPedidoRepository pedidoRepository, IUsuarioRepository usuarioRepository,
            IProdutoRepository produtoRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public List<Pedido> GetAllPorUsuario(string email, int skip, int take)
        {
            return _pedidoRepository.GetAllPorUsuario(email, skip, take);
        }

        public List<Pedido> GetAllPorUsuario(string email)
        {
            return _pedidoRepository.GetAllPorUsuario(email);
        }

        public List<Pedido> GetCriados(string email)
        {
            return _pedidoRepository.GetCriados(email);
        }

        public List<Pedido> GetPagos(string email)
        {
            return _pedidoRepository.GetPagos(email);
        }

        public List<Pedido> GetEntregues(string email)
        {
            return _pedidoRepository.GetEntregues(email);
        }

        public List<Pedido> GetCancelados(string email)
        {
            return _pedidoRepository.GetCancelados(email);
        }

        public Pedido GetDetalhes(int id, string email)
        {
            return _pedidoRepository.GetDetalhes(id, email);
        }

        public Pedido GetHeader(int id, string email)
        {
            return _pedidoRepository.GetHeader(id, email);
        }

        public void Cancelar(int id, string email)
        {
            var pedido = _pedidoRepository.GetHeader(id, email);
            pedido.MarcarComoCacelado();
            _pedidoRepository.Update(pedido);
        }

        public void Pagar(int id, string email)
        {
            var pedido = _pedidoRepository.GetHeader(id, email);
            pedido.MarcarComoPago();
            _pedidoRepository.Update(pedido);
        }

        public void Entregar(int id, string email)
        {
            var pedido = _pedidoRepository.GetHeader(id, email);
            pedido.MarcarComoEntregue();
            _pedidoRepository.Update(pedido);
        }

        public Pedido Create(Pedido pedido, string email)
        {
            var usuario = _usuarioRepository.GetByEmail(email);
            var itensPedido = new List<ItemPedido>();
            foreach (var item in pedido.ItensPedido)
            {
                var itemPedido = new ItemPedido();
                var produto = _produtoRepository.Get(item.Produto.Id);
                itemPedido.AdicionarProduto(produto, item.Quantidade, item.Preco);
                itensPedido.Add(itemPedido);
            }

            var pedidoAux = new Pedido(itensPedido, usuario.Id);
            pedidoAux.Registrar();

            if (Commit())
                return pedido;

            return null;
        }
    }
}
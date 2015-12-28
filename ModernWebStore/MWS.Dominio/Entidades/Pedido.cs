using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using MWS.Dominio.Enumeradores;

namespace MWS.Dominio.Entidades
{
    public class Pedido
    {
      private IList<ItemPedido> _itensPedido;

        public Pedido(IList<ItemPedido> itensPedido, int usuarioId)
        {
            Data = DateTime.Now;
            _itensPedido = new List<ItemPedido>();
            itensPedido.ToList().ForEach(x=> AdicionarItem(x));
            UsuarioId = usuarioId;
            Status = EPedidoStatus.Criado;
        }

        public int Id { get; private set; }
        public DateTime Data { get; private set; }

        public IEnumerable<ItemPedido> ItensPedido
        {
            get { return _itensPedido; }
            private set { _itensPedido = new List<ItemPedido>(value); }
        }

        public Usuario Usuario { get; private set; }
        public int UsuarioId { get; private set; }

        public Decimal Total
        {
            get
            {
                decimal total = 0;
                for (int i = 0; i < _itensPedido.Count; i++)
                {
                    total += _itensPedido[i].Preco*_itensPedido[i].Quantidade;
                }

                return total;
            }
            set { }
        }

        public EPedidoStatus Status { get; private set; }

        public void AdicionarItem(ItemPedido item)
        {
            if (item == null)
                throw new Exception("Item não pode ser nulo");

            if (item.Preco < 0)
                throw new Exception("preço do item não pode ser negativo");

            if (item.Quantidade <= 0)
                throw new Exception("A quantidade deve ser acima de zero");
            _itensPedido.Add(item);
        }
    }
}
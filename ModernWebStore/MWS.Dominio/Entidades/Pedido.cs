#region

using System;
using System.Collections.Generic;
using System.Linq;
using MWS.Dominio.Enumeradores;
using MWS.Dominio.Scope;

#endregion

namespace MWS.Dominio.Entidades
{
    public class Pedido
    {
        private IList<ItemPedido> _itensPedido;

        public Pedido(IList<ItemPedido> itensPedido, int usuarioId)
        {
            Data = DateTime.Now;
            _itensPedido = new List<ItemPedido>();
            itensPedido.ToList().ForEach(x => AdicionarItem(x));
            UsuarioId = usuarioId;
            Status = EPedidoStatus.Criado;
        }

        public int Id { get; private set; }
        public DateTime Data { get; private set; }

        public ICollection<ItemPedido> ItensPedido
        {
            get { return _itensPedido; }
            private set { _itensPedido = new List<ItemPedido>(value); }
        }

        public Usuario Usuario { get; private set; }
        public int UsuarioId { get; }

        public Decimal Total
        {
            get
            {
                decimal total = 0;
                for (var i = 0; i < _itensPedido.Count; i++)
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
            if (item.Registrar())
            {
                _itensPedido.Add(item);
            }
        }

        public void Registrar()
        {
            if (!this.RegistrarPedidoValido(UsuarioId))
                return;
        }

        public void MarcarComoPago()
        {
            Status = EPedidoStatus.Pago;
        }

        public void MarcarComoEntregue()
        {
            Status = EPedidoStatus.Entregue;
        }

        public void MarcarComoCacelado()
        {
            Status = EPedidoStatus.Cancelado;
        }
    }
}
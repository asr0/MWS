using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MWS.Dominio.Entidades;
using MWS.Dominio.Enumeradores;

namespace MWS.Dominio.Specs
{
    public static class PedidoSpecs
    {
        public static Expression<Func<Pedido, bool>> GetPedidosCriados(string email)
        {
            return x => x.Usuario.Email == email && x.Status == EPedidoStatus.Criado;
        }
        public static Expression<Func<Pedido, bool>> GetPedidosPagos(string email)
        {
            return x => x.Usuario.Email == email && x.Status == EPedidoStatus.Pago;
        }
        public static Expression<Func<Pedido, bool>> GetPedidosEntregues(string email)
        {
            return x => x.Usuario.Email == email && x.Status == EPedidoStatus.Entregue;
        }
        public static Expression<Func<Pedido, bool>> GetPedidosCancelados(string email)
        {
            return x => x.Usuario.Email == email && x.Status == EPedidoStatus.Cancelado;
        }
        public static Expression<Func<Pedido, bool>> GetPedidosUsuario(string email)
        {
            return x => x.Usuario.Email == email;
        }
        public static Expression<Func<Pedido, bool>> GetDetatlhesPedido(int id, string email)
        {
            return x => x.Usuario.Email == email && x.Id == id;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWS.Dominio.Entidades
{
 public class ItemPedido
    {
     public int Id { get; private set; }
     public int Quantidade { get; private set; }
     public decimal Preco { get;private set; }
     public int ProdutoId { get; private set; }
     public Produto Produto { get; private set; }
     public Pedido Pedido { get; private set; }
     public int PedidoId { get; private set; }


    }
}

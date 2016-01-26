#region

using System.Data.Entity.ModelConfiguration;
using MWS.Dominio.Entidades;

#endregion

namespace MWS.Infraestrutura.ORM.Map
{
    public class ItemPedidoMap : EntityTypeConfiguration<ItemPedido>
    {
        public ItemPedidoMap()
        {
            ToTable("ItensPedido");
            HasKey(x => x.Id);
            Property(x => x.Preco).IsRequired();
            Property(x => x.Quantidade).IsRequired();

            HasRequired(x => x.Pedido);
            HasRequired(x => x.Produto);
        }
    }
}
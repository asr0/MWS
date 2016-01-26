#region

using System.Data.Entity.ModelConfiguration;
using MWS.Dominio.Entidades;

#endregion

namespace MWS.Infraestrutura.ORM.Map
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            ToTable("Pedidos");
            HasKey(x => x.Id);
            Property(x => x.Data).IsRequired();
            Property(x => x.Status).IsRequired();
            Ignore(x => x.Total);
            HasRequired(x => x.Usuario);
            HasMany(x => x.ItensPedido).WithRequired(x => x.Pedido);
        }
    }
}
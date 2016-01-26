#region

using System.Data.Entity;
using MWS.Dominio.Entidades;
using MWS.Infraestrutura.ORM.Map;

#endregion

namespace MWS.Infraestrutura.ORM.DataContexts
{
    public class StoreDataContext : DbContext
    {
        public StoreDataContext() : base("StoreConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public ItemPedido ItensPedidos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new PedidoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new ItemPedidoMap());
        }
    }
}
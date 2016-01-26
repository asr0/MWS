#region

using System.Data.Entity.ModelConfiguration;
using MWS.Dominio.Entidades;

#endregion

namespace MWS.Infraestrutura.ORM.Map
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produtos");
            HasKey(x => x.Id);

            Property(x => x.Descricao)
                .HasMaxLength(1024)
                .IsRequired();

            Property(x => x.Preco)
                .IsRequired();

            Property(x => x.Quantidade)
                .IsRequired();

            Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(60);

            HasRequired(x => x.Categoria);
        }
    }
}
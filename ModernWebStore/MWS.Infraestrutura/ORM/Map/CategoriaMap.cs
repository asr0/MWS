#region

using System.Data.Entity.ModelConfiguration;
using MWS.Dominio.Entidades;

#endregion

namespace MWS.Infraestrutura.ORM.Map
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");
            HasKey(x => x.Id);
            Property(x => x.Titulo).HasMaxLength(60).IsRequired();
        }
    }
}
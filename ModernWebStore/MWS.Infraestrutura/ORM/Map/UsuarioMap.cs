#region

using System.Data.Entity.ModelConfiguration;
using MWS.Dominio.Entidades;

#endregion

namespace MWS.Infraestrutura.ORM.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            HasKey(X => X.Id);
            Property(x => x.Email).HasMaxLength(160).IsRequired();
            Property(x => x.Password).HasMaxLength(32).IsFixedLength().IsRequired();
            Property(x => x.IsAdmin).IsRequired();
        }
    }
}
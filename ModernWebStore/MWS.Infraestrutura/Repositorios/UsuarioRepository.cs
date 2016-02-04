#region

using System.Linq;
using MWS.Dominio.Entidades;
using MWS.Dominio.Repository;
using MWS.Dominio.Specs;
using MWS.Infraestrutura.ORM.DataContexts;

#endregion

namespace MWS.Infraestrutura.Repositorios
{
    public  class UsuarioRepository : IUsuarioRepository
    {
        private readonly StoreDataContext _context;

        public UsuarioRepository(StoreDataContext context)
        {
            _context = context;
        }

        public void Registrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public Usuario Autenticar(string email, string senha)
        {
            return _context.Usuarios.Where(UserSpecs.AutenticarUsuario(email, senha)).FirstOrDefault();
        }

        public Usuario GetByEmail(string email)
        {
            return _context.Usuarios.Where(UserSpecs.GetByEmail(email)).FirstOrDefault();
        }
    }
}
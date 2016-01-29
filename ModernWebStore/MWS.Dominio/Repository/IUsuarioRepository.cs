#region

using MWS.Dominio.Entidades;

#endregion

namespace MWS.Dominio.Repository
{
    public interface IUsuarioRepository
    {
        Usuario GetByEmail(string email);
        Usuario Autenticar(string email, string senha);
        void Registrar(Usuario usuario);
    }
}
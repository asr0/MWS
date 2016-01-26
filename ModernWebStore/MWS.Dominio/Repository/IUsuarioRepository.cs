#region

using MWS.Dominio.Entidades;

#endregion

namespace MWS.Dominio.Repository
{
    public interface IUsuarioRepository
    {
        Usuario Autenticar(string email, string senha);
        void Registrar(Usuario usuario);
    }
}
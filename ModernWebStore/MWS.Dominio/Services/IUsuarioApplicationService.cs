#region

using MWS.Dominio.Entidades;

#endregion

namespace MWS.Dominio.Services
{
    public interface IUsuarioApplicationService
    {
        Usuario Autenticar(string email, string senha);
        Usuario Registrar(Usuario usuario);
        Usuario GetByEmail(string email);
    }
}
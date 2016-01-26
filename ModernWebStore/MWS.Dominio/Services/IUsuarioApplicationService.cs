#region

using MWS.Dominio.Entidades;

#endregion

namespace MWS.Dominio.Services
{
    internal interface IUsuarioApplicationService
    {
        Usuario Autenticar(string email, string senha);
        void Registrar(Usuario usuario);
        Usuario GetByEmail(string email);
    }
}
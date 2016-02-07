#region

using MWS.Dominio.Entidades;
using MWS.Dominio.Repository;
using MWS.Dominio.Services;
using MWS.Infraestrutura.ORM;

#endregion

namespace MWS.Aplicacao
{
    public class UsuarioApplicationService : ApplicationServiceBase, IUsuarioApplicationService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioApplicationService(IUsuarioRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repository;
        }

        public Usuario Registrar(Usuario usuario)
        {
            usuario.Registrar();
            _repository.Registrar(usuario);

            if (Commit())
                return usuario;

            return null;
        }

        public Usuario Autenticar(string usuario, string senha)
        {
            return _repository.Autenticar(usuario, senha);
        }

        public Usuario GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }
    }
}
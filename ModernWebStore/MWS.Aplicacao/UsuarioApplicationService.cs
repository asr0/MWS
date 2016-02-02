using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWS.Dominio.Entidades;
using MWS.Dominio.Repository;
using MWS.Dominio.Services;
using MWS.Infraestrutura.ORM;

namespace MWS.Aplicacao
{
    class UsuarioApplicationService : ApplicationServiceBase, IUsuarioApplicationService
    {
        private IUsuarioRepository _repository;

        public UsuarioApplicationService(IUsuarioRepository repository, IUnitOfWork unitOfWork):base(unitOfWork)
        {
            this._repository = repository;
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

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
    public class CategoriaApplicationService : ApplicationServiceBase, ICategoriaApplicationService
    {
        private ICategoriaRepository _repository;

        public CategoriaApplicationService(ICategoriaRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Categoria Create(Categoria categoria)
        {
            categoria.Register();
            _repository.Create(categoria);

            if (Commit())
                return categoria;

            return null;
        }

        public List<Categoria> GetInPadding(int skip, int take)
        {
            return _repository.GetinPadding(skip, take);
        }

        public List<Categoria> GetAll()
        {
            return _repository.GetAll();
        }

        public Categoria Get(int id)
        {
            return _repository.Get(id);
        }

        public void Delete(Categoria categoria)
        {
            _repository.Delete(categoria);
        }


        public void Delete(int id)
        {
            _repository.Delete(id);
        }


        public Categoria Update(Categoria cat)
        {
            var categoria = _repository.Get(cat.Id);
            categoria.AtualizarTitulo(cat.Titulo);

            _repository.Update(cat);
            if (Commit())
                return categoria;

            return null;
        }



    }
}

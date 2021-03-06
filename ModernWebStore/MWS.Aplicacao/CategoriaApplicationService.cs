﻿#region

using System.Collections.Generic;
using MWS.Dominio.Entidades;
using MWS.Dominio.Repository;
using MWS.Dominio.Services;
using MWS.Infraestrutura.ORM;

#endregion

namespace MWS.Aplicacao
{
    public class CategoriaApplicationService : ApplicationServiceBase, ICategoriaApplicationService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaApplicationService(ICategoriaRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repository;
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

        public Categoria Delete(Categoria categoria)
        {
            _repository.Delete(categoria);
            if (Commit())
                return categoria;

            return null;
        }

        public Categoria Delete(int id)
        {
            var categoria = _repository.Get(id);
            _repository.Delete(id);

            if (Commit())
                return categoria;

            return null;
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
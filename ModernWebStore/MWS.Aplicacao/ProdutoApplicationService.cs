#region

using System.Collections.Generic;
using MWS.Dominio.Entidades;
using MWS.Dominio.Repository;
using MWS.Dominio.Services;
using MWS.Infraestrutura.ORM;

#endregion

namespace MWS.Aplicacao
{
    public class ProdutoApplicationService : ApplicationServiceBase, IProdutoApplicationService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoApplicationService(IProdutoRepository repository, IUnitOfWork unitOfwork) : base(unitOfwork)
        {
            _repository = repository;
        }

        public Produto Create(Produto produto)
        {
            produto.RegistrarProduto();
            _repository.Create(produto);

            return (Commit()) ? produto : null;
        }

        public Produto Update(Produto produto)
        {
            produto.RegistrarProduto();
            _repository.Update(produto);

            return (Commit()) ? produto : null;
        }

        public Produto Delete(Produto produto)
        {
            _repository.Delete(_repository.Get(produto.Id));
            return (Commit()) ? produto : null;
        }

        public Produto Delete(int id)
        {
            var prod = _repository.Get(id);
            _repository.Delete(prod);
            return (Commit()) ? prod : null;
        }

        public List<Produto> GetProdutosForaDeEstoque()
        {
            return _repository.GetProdutosForaDeEstoque();
        }

        public List<Produto> GetProdutosEmEstoque()
        {
            return _repository.GetProdutosEmEstoque();
        }

        public List<Produto> GetInPadding(int skip, int take)
        {
            return _repository.GetInPadding(skip, take);
        }

        public List<Produto> GetAll()
        {
            return _repository.GetAll();
        }

        public Produto Get(int id)
        {
            return _repository.Get(id);
        }
    }
}
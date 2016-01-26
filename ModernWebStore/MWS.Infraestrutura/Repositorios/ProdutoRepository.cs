#region

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MWS.Dominio.Entidades;
using MWS.Dominio.Repository;
using MWS.Dominio.Specs;
using MWS.Infraestrutura.ORM.DataContexts;

#endregion

namespace MWS.Infraestrutura.Repositorios
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly StoreDataContext _context;

        public ProdutoRepository(StoreDataContext context)
        {
            _context = context;
        }

        public List<Produto> GetInPadding(int skip, int take)
        {
            return _context.Produtos.OrderBy(x => x.Id).Skip(skip).Take(take).ToList();
        }

        public List<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public List<Produto> GetProdutosEmEstoque()
        {
            return _context.Produtos.Where(ProdutosSpecs.GetProdutosEmEstoque()).ToList();
        }

        public List<Produto> GetProdutosForaDeEstoque()
        {
            return _context.Produtos.Where(ProdutosSpecs.GetProdutosForaDeEstoque()).ToList();
        }

        public Produto Get(int id)
        {
            return _context.Produtos.Find(id);
        }

        public void Create(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Update(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            _context.Produtos.Remove(_context.Produtos.Find(id));
        }

        public void Delete(Produto produto)
        {
            _context.Produtos.Remove(produto);
        }
    }
}
using System.Collections.Generic;
using MWS.Dominio.Entidades;

namespace MWS.Dominio.Repository
{
    public interface IProdutoRepository
    {
        List<Produto> GetAll();
        List<Produto> GetAll(int skip, int take);
        List<Produto> GetProdutosEmEstoque();
        List<Produto> GetProdutosForaDeEstoque();
        Produto Get(int id);
        void Create(Produto produto);
        void Update(Produto produto);
        void Delete(Produto produto);
        void Delete(int id);
    }
}
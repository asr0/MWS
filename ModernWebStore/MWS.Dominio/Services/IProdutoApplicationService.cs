#region

using System.Collections.Generic;
using MWS.Dominio.Entidades;

#endregion

namespace MWS.Dominio.Services
{
    public interface IProdutoApplicationService
    {
        List<Produto> GetAll();
        List<Produto> GetInPadding(int skip, int take);
        List<Produto> GetProdutosEmEstoque();
        List<Produto> GetProdutosForaDeEstoque();
        Produto Get(int id);
        Produto Create(Produto produto);
        Produto Update(Produto produto);
        Produto Delete(Produto produto);
        Produto Delete(int id);
    }
}
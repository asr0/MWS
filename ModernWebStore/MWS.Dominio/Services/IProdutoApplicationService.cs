using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWS.Dominio.Entidades;

namespace MWS.Dominio.Services
{
    interface IProdutoApplicationService
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

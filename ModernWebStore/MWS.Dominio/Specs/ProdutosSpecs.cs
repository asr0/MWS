using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MWS.Dominio.Entidades;

namespace MWS.Dominio.Specs
{
    public static class ProdutosSpecs
    {
        public static Expression<Func<Produto, bool>> GetProdutosEmEstoque()
        {
            return x => x.Quantidade > 0;
        }

        public static Expression<Func<Produto, bool>> GetProdutosForaDeEstoque()
        {
            return x => x.Quantidade < 1;
        }

    }
}

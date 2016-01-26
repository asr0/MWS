#region

using System;
using System.Linq.Expressions;
using MWS.Dominio.Entidades;

#endregion

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
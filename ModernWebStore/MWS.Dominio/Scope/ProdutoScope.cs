#region

using MWS.Dominio.Entidades;
using MWS.NucleoCompartilhado.Validacao;

#endregion

namespace MWS.Dominio.Scope
{
    public static class ProdutoScope
    {
        public static bool RegistrarProdutoValido(this Produto produto)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotNull(produto.Titulo, "O titulo do produto é obrigatório"),
                AssertionConcern.AssertNotNull(produto.Descricao, "A descrição do produto é obrigatória"),
                AssertionConcern.AssertIsGreaterThan(produto.CategoriaId, 0, "A categria do produto é obrigatória"),
                AssertionConcern.AssertIsGreaterOrEqualThan(produto.Preco, 0,
                    "O preço do produto não pode ser menor que zero"),
                AssertionConcern.AssertIsGreaterThan(produto.Quantidade, 0, "A quantidade do produto não pode ser zero")
                );
        }

        public static bool AtualizarQuantidadeValido(this Produto produto, int qtd)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertIsGreaterOrEqualThan(qtd, 0, "A quantidade não pode ser menor que zero.")
                );
        }

        public static bool AtualizarPrecoValido(this Produto produto, decimal preco)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertIsGreaterOrEqualThan(preco, 0, "O preço do produto não pode ser menor que zero.")
                );
        }

        public static bool AtualizarInformacoesValido(this Produto produto, string titulo, string descricao,
            int categoria)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotNull(titulo, "O titulo do produto é obrigatório"),
                AssertionConcern.AssertNotNull(descricao, "A descrição do produto é obrigatória"),
                AssertionConcern.AssertIsGreaterThan(categoria, 0, "A categria do produto é obrigatória"));
        }
    }
}
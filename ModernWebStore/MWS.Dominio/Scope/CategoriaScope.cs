#region

using MWS.Dominio.Entidades;
using MWS.NucleoCompartilhado.Validacao;

#endregion

namespace MWS.Dominio.Scope
{
    public static class CategoriaScope
    {
        public static bool CriacaoCategoriaValida(this Categoria categoria)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(categoria.Titulo, "O titulo é obrigatório"),
                    AssertionConcern.AssertLength(categoria.Titulo, 3, 20, "Tamanho em caracteres invalido")
                );
        }

        public static bool AlteracaoCategoriaValida(this Categoria categoria)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertNotEmpty(categoria.Titulo, "O titulo é obrigatório"),
                AssertionConcern.AssertLength(categoria.Titulo, 3, 20, "Tamanho em caracteres invalido")
                );
        }
    }
}
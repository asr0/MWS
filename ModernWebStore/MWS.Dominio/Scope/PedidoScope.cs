#region

using System.Linq;
using MWS.Dominio.Entidades;
using MWS.NucleoCompartilhado.Validacao;

#endregion

namespace MWS.Dominio.Scope
{
    public static class PedidoScope
    {
        public static bool RegistrarPedidoValido(this Pedido pedido, int usuarioId)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertIsGreaterThan(pedido.ItensPedido.Count(), 0, "Nenhum item foi adicionado"),
                AssertionConcern.AssertIsGreaterThan(usuarioId, 0, "O pedido deve ter um usuario.")
                );
        }
    }
}
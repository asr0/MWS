#region

using System.Linq;
using MWS.Dominio.Entidades;
using MWS.NucleoCompartilhado.Validacao;

#endregion

namespace MWS.Dominio.Scope
{
    public static class PedidoScope
    {
        public static bool RegistrarPedidoValido(this Pedido pedido, string usuarioEmail)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertIsGreaterThan(pedido.ItensPedido.Count(), 0, "Nenhum item foi adicionado"),
                AssertionConcern.AssertNotEmpty(usuarioEmail,  "O pedido deve ter um usuario."),
                AssertionConcern.AssertEmailIsValid(usuarioEmail, "O pedido deve ter um usuario com email Válido")
                
                );
        }
    }
}
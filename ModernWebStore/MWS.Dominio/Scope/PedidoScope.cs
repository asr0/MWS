using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWS.Dominio.Entidades;
using MWS.NucleoCompartilhado.Validacao;

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

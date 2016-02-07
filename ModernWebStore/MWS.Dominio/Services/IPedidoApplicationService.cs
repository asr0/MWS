#region

using System.Collections.Generic;
using MWS.Dominio.Entidades;

#endregion

namespace MWS.Dominio.Services
{
    public interface IPedidoApplicationService
    {
        List<Pedido> GetAllPorUsuario(string email, int skip, int take);
        List<Pedido> GetAllPorUsuario(string email);
        List<Pedido> GetCriados(string email);
        List<Pedido> GetPagos(string email);
        List<Pedido> GetEntregues(string email);
        List<Pedido> GetCancelados(string email);
        Pedido GetDetalhes(int id, string email);
        Pedido GetHeader(int id, string email);
        Pedido Create(Pedido pedido, string email);
        void Pagar(int id, string email);
        void Entregar(int id, string email);
        void Cancelar(int id, string email);
    }
}
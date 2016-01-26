#region

using System.Collections.Generic;
using MWS.Dominio.Entidades;

#endregion

namespace MWS.Dominio.Repository
{
    public interface IPedidoRepository
    {
        List<Pedido> GetAllPorUsuario(string email, int skip, int take);
        List<Pedido> GetAllPorUsuario(string email);
        List<Pedido> GetCriados(string email);
        List<Pedido> GetPagos(string email);
        List<Pedido> GetEntregues(string email);
        List<Pedido> GetCancelados(string email);
        Pedido GetDetalhes(int id, string email);
        Pedido GetHeader(int id, string email);
        void Create(Pedido pedido);
        void Update(Pedido pedido);
        void Delete(Pedido pedido);
        void Delete(int id);
    }
}
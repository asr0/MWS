using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWS.Dominio.Entidades;

namespace MWS.Dominio.Services
{
    interface IPedidoApplicationService
    {
        List<Pedido> GetAllPorUsuario(string email, int skip, int take);
        List<Pedido> GetAllPorUsuario(string email);
        List<Pedido> GetCriados(string email);
        List<Pedido> GetPagos(string email);
        List<Pedido> GetEntregues(string email);
        List<Pedido> GetCancelados(string email);
        Pedido GetDetalhes(int id, string email);
        Pedido GetHeader(int id, string email);
        void Create(Pedido pedido, string email);
        void Pagar(int id, string email);
        void Entregar(int id, string email);
        void Cancelar(int id, string email);

    }
}

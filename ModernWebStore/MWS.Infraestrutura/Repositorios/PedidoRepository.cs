#region

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MWS.Dominio.Entidades;
using MWS.Dominio.Repository;
using MWS.Dominio.Specs;
using MWS.Infraestrutura.ORM.DataContexts;

#endregion

namespace MWS.Infraestrutura.Repositorios
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly StoreDataContext _context;

        public PedidoRepository(StoreDataContext context)
        {
            _context = context;
        }

        public void Create(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
        }

        public void Delete(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
        }

        public void Delete(int id)
        {
            _context.Pedidos.Remove(_context.Pedidos.Find(id));
        }

        public void Update(Pedido pedido)
        {
            _context.Entry(pedido).State = EntityState.Modified;
        }

        public List<Pedido> GetAllPorUsuario(string email, int skip, int take)
        {
            return _context.Pedidos.Where(PedidoSpecs.GetPedidosUsuario(email))
                .OrderByDescending(x => x.Data)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public List<Pedido> GetAllPorUsuario(string email)
        {
            return _context.Pedidos.Where(PedidoSpecs.GetPedidosUsuario(email)).OrderByDescending(x => x.Data).ToList();
        }

        public List<Pedido> GetCriados(string email)
        {
            return _context.Pedidos.Where(PedidoSpecs.GetPedidosCriados(email)).OrderByDescending(x => x.Data).ToList();
        }

        public List<Pedido> GetPagos(string email)
        {
            return _context.Pedidos.Where(PedidoSpecs.GetPedidosPagos(email)).OrderByDescending(x => x.Data).ToList();
        }

        public List<Pedido> GetEntregues(string email)
        {
            return
                _context.Pedidos.Where(PedidoSpecs.GetPedidosEntregues(email)).OrderByDescending(x => x.Data).ToList();
        }

        public List<Pedido> GetCancelados(string email)
        {
            return
                _context.Pedidos.Where(PedidoSpecs.GetPedidosCancelados(email)).OrderByDescending(x => x.Data).ToList();
        }

        public Pedido GetDetalhes(int id, string email)
        {
            return
                _context.Pedidos.Include(x => x.ItensPedido)
                    .Where(PedidoSpecs.GetDetalhesPedido(id, email))
                    .FirstOrDefault();
        }

        public Pedido GetHeader(int id, string email)
        {
            return _context.Pedidos.Where(PedidoSpecs.GetDetalhesPedido(id, email)).FirstOrDefault();
        }

        public List<Pedido> GetAll()
        {
            return _context.Pedidos.ToList();
        }
    }
}
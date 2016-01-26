#region

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MWS.Dominio.Entidades;
using MWS.Dominio.Repository;
using MWS.Infraestrutura.ORM.DataContexts;

#endregion

namespace MWS.Infraestrutura.Repositorios
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly StoreDataContext _context;

        public CategoriaRepository(StoreDataContext context)
        {
            _context = context;
        }

        public void Create(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
        }

        public void Delete(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
        }

        public void Delete(int id)
        {
            _context.Categorias.Remove(_context.Categorias.Find(id));
        }

        public void Update(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
        }

        public Categoria Get(int id)
        {
            return _context.Categorias.Find(id);
        }

        public Categoria Get(Categoria categoria)
        {
            return _context.Categorias.Find(categoria);
        }

        public List<Categoria> GetAll()
        {
            return _context.Categorias.ToList();
        }

        public List<Categoria> GetinPadding(int skip, int take)
        {
            return _context.Categorias.OrderBy(x => x.Id)
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }
}
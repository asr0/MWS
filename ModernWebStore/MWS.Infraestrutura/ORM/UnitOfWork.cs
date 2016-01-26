#region

using MWS.Infraestrutura.ORM.DataContexts;

#endregion

namespace MWS.Infraestrutura.ORM
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(StoreDataContext context)
        {
            _context = context;
        }

        public StoreDataContext _context { get; set; }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
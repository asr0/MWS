#region

using System;

#endregion

namespace MWS.Infraestrutura.ORM
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
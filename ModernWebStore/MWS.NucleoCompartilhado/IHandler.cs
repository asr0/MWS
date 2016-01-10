#region

using System;
using System.Collections.Generic;
using MWS.NucleoCompartilhado.Eventos.Contratos;

#endregion

namespace MWS.NucleoCompartilhado
{
    public interface IHandler<T> : IDisposable where T : IEventoDominio
    {
        void Handle(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
    }
}
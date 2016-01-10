#region

using System;
using System.Collections.Generic;

#endregion

namespace MWS.NucleoCompartilhado
{
    public interface IContainer
    {
        T GetService<T>();
        object GetService(Type servType);
        IEnumerable<T> GetServices<T>();
        IEnumerable<object> GetServices(Type servicesType);
    }
}
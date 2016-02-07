#region

using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using MWS.NucleoCompartilhado;

#endregion

namespace MWS.Api.Helpers
{
    public class DomainEventsContainer : IContainer
    {
        private readonly IDependencyResolver _resolver;

        public DomainEventsContainer(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            return _resolver.GetService(serviceType);
        }

        public T GetService<T>()
        {
            return (T) _resolver.GetService(typeof (T));
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolver.GetServices(serviceType);
        }

        public IEnumerable<T> GetServices<T>()
        {
            return (IEnumerable<T>) _resolver.GetServices(typeof (T));
        }
    }
}
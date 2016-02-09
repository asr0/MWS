#region

using System;

#endregion

namespace MWS.NucleoCompartilhado.Eventos.Contratos
{
    public static class EventoDominio
    {
        public static IContainer Container { get; set; }

        public static void Raise<T>(T args) where T : IEventoDominio
        {
            try
            {
                if (Container != null)
                {
                    var obj = Container.GetService(typeof (IHandler<T>));
                    ((IHandler<T>)obj).Handle(args);
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
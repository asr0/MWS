using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWS.NucleoCompartilhado;
using MWS.NucleoCompartilhado.Eventos.Contratos;

namespace MWS.CrossCutting
{
 public  class NotificacaoDominioHandler : IHandler<NotificacaoDominio>
 {
     private List<NotificacaoDominio> _notificacoes;

     public NotificacaoDominioHandler()
     {
            _notificacoes = new List<NotificacaoDominio>();
     }

     public void Handle(NotificacaoDominio args)
     {
         _notificacoes.Add(args);
     }

     public IEnumerable<NotificacaoDominio> Notify()
     {
         return GetValue();
     }

     private List<NotificacaoDominio> GetValue()
     {
         return _notificacoes;
     }

     public bool HasNotifications()
     {
         return GetValue().Count > 0;
     }

     public void Dispose()
     {
         _notificacoes = new List<NotificacaoDominio>();
     }
 }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWS.Infraestrutura.ORM;
using MWS.NucleoCompartilhado;
using MWS.NucleoCompartilhado.Eventos.Contratos;

namespace MWS.Aplicacao
{
    public class ApplicationServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private IHandler<NotificacaoDominio> _notificacoes;
        public ApplicationServiceBase(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._notificacoes = EventoDominio.Container.GetService<IHandler<NotificacaoDominio>>();
        }

        public bool Commit()
        {
            if (_notificacoes.HasNotifications())
                return false;
            
            _unitOfWork.Commit();
            return true;
        }
    }
}

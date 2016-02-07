#region

using MWS.Infraestrutura.ORM;
using MWS.NucleoCompartilhado;
using MWS.NucleoCompartilhado.Eventos.Contratos;

#endregion

namespace MWS.Aplicacao
{
    public class ApplicationServiceBase
    {
        private readonly IHandler<NotificacaoDominio> _notificacoes;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _notificacoes = EventoDominio.Container.GetService<IHandler<NotificacaoDominio>>();
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
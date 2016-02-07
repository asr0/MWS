#region

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MWS.NucleoCompartilhado;
using MWS.NucleoCompartilhado.Eventos.Contratos;

#endregion

namespace MWS.Api.Controllers
{
    public class BaseController : ApiController
    {
        public IHandler<NotificacaoDominio> Notifications;
        public HttpResponseMessage ResponseMenssage;

        public BaseController()
        {
            Notifications = EventoDominio.Container.GetService<IHandler<NotificacaoDominio>>();
            ResponseMenssage = new HttpResponseMessage();
        }

        protected override void Dispose(bool disposing)
        {
            Notifications.Dispose();
        }

        public Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            if (Notifications.HasNotifications())
                ResponseMenssage = Request.CreateResponse(HttpStatusCode.BadRequest,
                    new {errors = Notifications.Notify()});

            else
                ResponseMenssage = Request.CreateResponse(code, result);


            return Task.FromResult(ResponseMenssage);
        }
    }
}

using MWS.Dominio.Entidades;
using MWS.Dominio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MWS.Api.Controllers
{
    public class PedidoController: BaseController
    {
        IPedidoApplicationService _service;

        public PedidoController(IPedidoApplicationService service)
        {
            this._service = service;
        }


        #region GET PEDIDOS 

        [HttpGet]
        [Route("api/pedidos")]
        public Task<HttpResponseMessage> Get()
        {
            var resultado = _service.GetAllPorUsuario(User.Identity.Name);
            return CreateResponse(HttpStatusCode.OK, resultado);
        }

        [HttpGet]
        [Route("api/pedidos/criados")]
        public Task<HttpResponseMessage> GetCriados()
        {
            var resultado = _service.GetCriados(User.Identity.Name);
            return CreateResponse(HttpStatusCode.OK, resultado);
        }

        [HttpGet]
        [Route("api/pedidos/pagos")]
        public Task<HttpResponseMessage> GetPagos()
        {
            var resultado = _service.GetPagos(User.Identity.Name);
            return CreateResponse(HttpStatusCode.OK, resultado);
        }

        [HttpGet]
        [Route("api/pedidos/entregues")]
        public Task<HttpResponseMessage> GetEntregues()
        {
            var resultado = _service.GetEntregues(User.Identity.Name);
            return CreateResponse(HttpStatusCode.OK, resultado);
        }

        [HttpGet]
        [Route("api/pedidos/cancelados")]
        public Task<HttpResponseMessage> GetCancelados()
        {
            var resultado = _service.GetCancelados(User.Identity.Name);
            return CreateResponse(HttpStatusCode.OK, resultado);
        }
        

        [HttpGet]
        [Route("api/pedidos/detalhes/{Id}")]
        public Task<HttpResponseMessage> GetDetalhes(int id)
        {
            var resultado = _service.GetDetalhes(id,User.Identity.Name);
            return CreateResponse(HttpStatusCode.OK, resultado);
        }

        [HttpGet]
        [Route("api/pedidos/header/{Id}")]
        public Task<HttpResponseMessage> GetHeader(int id)
        {
            var resultado = _service.GetHeader(id, User.Identity.Name);
            return CreateResponse(HttpStatusCode.OK, resultado);
        }

        #endregion

        [HttpPost]
        [Route("api/pedidos")]
        [Authorize]
        public Task<HttpResponseMessage> Post([FromBody] dynamic body)
        {
            var itensPedido = body.itensPedido.ToObject<List<ItemPedido>>();
            var pedido = new Pedido(itensPedido,User.Identity.Name);
            var resultado = _service.Create(pedido, User.Identity.Name);
            return CreateResponse(HttpStatusCode.Created, pedido);
        }



    }
}
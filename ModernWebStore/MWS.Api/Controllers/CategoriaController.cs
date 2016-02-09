using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MWS.Dominio.Entidades;
using MWS.Dominio.Services;
using System.Threading.Tasks;

namespace MWS.Api.Controllers
{
    public class CategoriaController : BaseController
    {
        private  ICategoriaApplicationService _service;

        public CategoriaController(ICategoriaApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        
        [Route("api/categorias")]
        public Task<HttpResponseMessage> Get()
        {
            var categorias = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, categorias);
        }

        [HttpGet]
        //[Authorize]
        [Route("api/categorias/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            var categoria = _service.Get(id);
            return CreateResponse(HttpStatusCode.OK, categoria);
        }

        [HttpPost]
        //[Authorize]
        [Route("api/categorias")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var categoria = new Categoria(titulo: (string)body.titulo );
            var resultado = _service.Create(categoria);
            return CreateResponse(HttpStatusCode.Created, resultado);
        }


        [HttpPut]
        //[Authorize]
        [Route("api/categorias")]
        public Task<HttpResponseMessage> Put(int id,[FromBody]dynamic body)
        {
            var categoria = new Categoria(id,(string)body.titulo);
            var resultado = _service.Update(categoria);
            return CreateResponse(HttpStatusCode.OK, resultado);
        }

        [HttpDelete]
        //[Authorize]
        [Route("api/categorias/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var categoria = _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, categoria);
        }




    }
}

using MWS.Dominio.Entidades;
using MWS.Dominio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MWS.Api.Controllers
{
    public class ProdutoController : BaseController
    {
        IProdutoApplicationService _service;
        public ProdutoController(IProdutoApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/produtos")]
        public Task<HttpResponseMessage> Get()
        {
            var resultado = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, resultado);
        }

        [HttpGet]
        [Route("api/produtos/{skip:int:min(0)/take:int:min(1)}")]
        public Task<HttpResponseMessage> GetByRange(int skip, int take)
        {
            var resultado = _service.GetInPadding(skip,take);
            return CreateResponse(HttpStatusCode.OK, resultado);
        }

        [HttpGet]
        [Route("api/produtos/foraDeEstoque")]
        public Task<HttpResponseMessage> GetForaDeEstoque()
        {
            var resultado = _service.GetProdutosForaDeEstoque();
            return CreateResponse(HttpStatusCode.OK, resultado);
        }

        [HttpGet]
        [Route("api/produtos/emEstoque")]
        public Task<HttpResponseMessage> GetEstoque()
        {
            var resultado = _service.GetProdutosEmEstoque();
            return CreateResponse(HttpStatusCode.OK, resultado);
        }

        [HttpPost]
        [Route("api/produtos")]
        public Task<HttpResponseMessage> Create([FromBody] dynamic body)
        {
            Produto produto = new Produto(
                titulo:(string)body.titulo,
                descricao:(string)body.descricao,
                preco:(decimal)body.preco,
                quantidade:(int)body.quantidade,
                categoriaId:(int)body.categoria
                );
            var resultado = _service.Create(produto);
            return CreateResponse(HttpStatusCode.OK, resultado);
        }

        [HttpPut]
        [Route("api/produtos/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody] dynamic body)
        {
            Produto produto = new Produto(id:id,
                titulo: (string)body.titulo,
                descricao: (string)body.descricao,
                preco: (decimal)body.preco,
                quantidade: (int)body.quantidade,
                categoriaId: (int)body.categoria
                );

            var resultado = _service.Update(produto);
            return CreateResponse(HttpStatusCode.OK, resultado);
        }

        [HttpDelete]
        [Route("api/produtos/{id:int:min(1)}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var resultado = _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, resultado);
        }


    }
}

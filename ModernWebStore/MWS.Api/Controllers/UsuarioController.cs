﻿#region

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MWS.Dominio.Entidades;
using MWS.Dominio.Services;
using System.Collections.Generic;

#endregion

namespace MWS.Api.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioApplicationService _service;


        public UsuarioController(IUsuarioApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/usuarios")]
        public Task<HttpResponseMessage> Post([FromBody] dynamic body)
        {
            var usuario = new Usuario((string)body.email, (string)body.password, (bool)body.isAdmin);
            var resultado = _service.Registrar(usuario);
            return CreateResponse(HttpStatusCode.Created, resultado);
        }

        [HttpGet]
        [Route("api/usuarios")]
        [Authorize(Roles ="admin")]
        public string Get()
        {
            return  User.Identity.Name;
        }
        


    }
}
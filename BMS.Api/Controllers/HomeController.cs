using System.Collections.Generic;
using BMS.Domain.Commands;
using BMS.Domain.Entities;
using BMS.Domain.Repositories.Interfaces;
using BMS.Shared.Commands;
using BMS.Shared.Handlers.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BMS.Api.Controllers
{
    [ApiController]
    [Route("v1/home")]
    public class HomeController : ControllerBase
    {
        private readonly IHandler<CriaUsuarioCommand> _handler;
        private readonly IRepository _repository;
        public HomeController(IHandler<CriaUsuarioCommand> handler, IRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }
        
        [HttpPost]
        [Route("novousuario")]
        public GenericCommandResult CriaUsuario(
            [FromBody] CriaUsuarioCommand command
        )
        {
            return (GenericCommandResult) _handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public List<Usuario> RetornaUsuarios()
        {
            return _repository.RetornaTodosUsuarios();
        }

        // [Route("")]
        // [HttpPost]
        // public GenericCommandResult GeraVenda()
        // {

        // }


    }
}
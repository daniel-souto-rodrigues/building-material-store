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
    [Route("v1/user")]
    public class HomeController : ControllerBase
    {
        private readonly IHandler<CriaUsuarioCommand> _handler;
        private readonly IRepository _repository;

        public HomeController(
        IHandler<CriaUsuarioCommand> handler,
        IRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        [Route("newuser")]
        public GenericCommandResult CriaUsuario(
            [FromBody] CriaUsuarioCommand command
        )
        {
            return (GenericCommandResult)_handler.Handle(command);
        }

        /*  test method  */
        [Route("")]
        [HttpGet]
        public IEnumerable<Usuario> RetornaUsuarios()
        {
            return _repository.RetornaTodosUsuarios();
        }
        /* ------------- */
    }
}
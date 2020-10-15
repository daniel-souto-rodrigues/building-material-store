using BMS.Domain.Commands;
using BMS.Domain.Repositories.Interfaces;
using BMS.Shared.Commands;
using BMS.Shared.Handlers.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BMS.Api.Controllers
{
    [ApiController]
    [Route("v1/Venda")]
    public class VendaController : ControllerBase
    {
        private readonly IHandler<GeraVendaCommand> _handler;
        private readonly IRepository _repository;

        public VendaController(
        IHandler<GeraVendaCommand> handler,
        IRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        [Route("")]
        public GenericCommandResult GeraVenda(
            [FromBody] GeraVendaCommand command
        )
        {
            return (GenericCommandResult)_handler.Handle(command);
        }

    }
}
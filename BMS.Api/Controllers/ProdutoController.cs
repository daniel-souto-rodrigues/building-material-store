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
    [Route("v1/product")]
    public class ProdutoController : ControllerBase
    {
        private readonly IHandler<CadastraProdutoCommand> _handler;
        private readonly IRepository _repository;

        public ProdutoController(
        IHandler<CadastraProdutoCommand> handler,
        IRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        [Route("new")]
        public GenericCommandResult CadastraProduto(
            [FromBody] CadastraProdutoCommand command
        )
        {
            return (GenericCommandResult)_handler.Handle(command);
        }

        [HttpGet]
        [Route("")]
        public Produto ProcuraProduto([FromBody] int codigo)
        {
            return _repository.ProcuraProdutoPorCodigo(codigo);
        }

        [HttpPut] 
        [Route("{codigo:int}")]
        public GenericCommandResult AtualizaProduto(int codigo, [FromBody] CadastraProdutoCommand command)
        {
            if (_repository.ProcuraProdutoPorCodigo(codigo) == null)
                return new GenericCommandResult(false, "o produto a ser atualizado não se encontra na base", command);
            else
            {
                var produto = new Produto(command.Nome, command.Codigo, command.Descricao, command.PrecoCusto, command.PrecoVenda);
                _repository.Atualiza(produto);
                return new GenericCommandResult(true, "o produto foi atualizado com sucesso", produto);
            }
        }

        [HttpDelete]
        [Route("{codigo:int}")]
        public GenericCommandResult DeletaProduto([FromRoute] int codigo)
        {
            var produto = _repository.ProcuraProdutoPorCodigo(codigo);
            _repository.DeletaProduto(codigo);
            return new GenericCommandResult(true, "produto foi deletado com sucesso", produto);
        }

        /*  test method  */
        [HttpGet]
        [Route("all")]
        public IEnumerable<Produto> RetornaProdutos()
        {
            return _repository.RetornaTodosProdutos();
        }
        /* ------------- */

    }
}
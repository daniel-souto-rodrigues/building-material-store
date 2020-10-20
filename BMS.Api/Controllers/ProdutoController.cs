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
        public GenericCommandResult CadastraProduto([FromBody] CadastraProdutoCommand command)
        {
            return (GenericCommandResult)_handler.Handle(command);
        }

        [HttpGet]
        [Route("")]
        public Produto ProcuraProduto([FromBody] string codigo)
        {
            return _repository.ProcuraProdutoPorCodigo(codigo);
        }

        [HttpPut]
        [Route("{codigo}")]
        public GenericCommandResult AtualizaProduto(string codigo, [FromBody] CadastraProdutoCommand command)
        {
            if (codigo != command.Codigo)
                return new GenericCommandResult(false, "o código do produto a ser atualizado não está correto", command);
            if (_repository.ProcuraProdutoPorCodigo(codigo) == null)
                return new GenericCommandResult(false, "o produto a ser atualizado não se encontra na base", command);
            if (!command.Validate())
                return new GenericCommandResult(false, "ops, parece que ocorreu algum erro", command.Notificacoes);
            else
            {
                var produto = new Produto(command.Nome, command.Codigo, command.Descricao, command.PrecoCusto, command.PrecoVenda);
                _repository.Atualiza(produto);
                return new GenericCommandResult(true, "o produto foi atualizado com sucesso", produto);
            }
        }

        [HttpDelete]
        [Route("{codigo}")]
        public GenericCommandResult DeletaProduto([FromRoute] string codigo)
        {
            var produto = _repository.ProcuraProdutoPorCodigo(codigo);

            if (produto == null)
                return new GenericCommandResult(false, "produto nao encontrado na base", codigo);
            if (produto.Deletado == true)
                return new GenericCommandResult(false, "O produto já foi deletado anteriormente", produto);

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
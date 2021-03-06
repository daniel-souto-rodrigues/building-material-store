using BMS.Domain.Commands;
using BMS.Domain.Entities;
using BMS.Domain.Repositories.Interfaces;
using BMS.Shared.Commands;
using BMS.Shared.Commands.Contracts;
using BMS.Shared.Entities;
using BMS.Shared.Handlers.Contracts;

namespace BMS.Domain.Handlers
{
    public class CadastraProdutoHandler : Notificavel, IHandler<CadastraProdutoCommand>
    {
        private readonly IRepository _repository;

        public CadastraProdutoHandler(IRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CadastraProdutoCommand command)
        {
            //fast validation
            if(!command.Validate())
                return new GenericCommandResult(false, "ops, parece que ocorreu algum erro", command.Notificacoes);

            //gera um produto
            var produto = new Produto(command.Nome, command.Codigo, command.Descricao, command.PrecoCusto, command.PrecoVenda);

            //verifica pelo código se o produto já existe no banco 
            if(_repository.ProcuraProdutoPorCodigo(produto.Codigo) != null)
                return new GenericCommandResult(false, "Ops, o produto já existe na base de dados", command.Notificacoes);
            
            //salva no banco
            _repository.Cria(produto);

            //retorno
            return new GenericCommandResult(true, "Produto cadastrado com sucesso", command);
        }
    }
}
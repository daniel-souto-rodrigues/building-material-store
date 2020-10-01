using BMS.Domain.Commands;
using BMS.Domain.Entities;
using BMS.Domain.Repositories.Interfaces;
using BMS.Shared.Commands;
using BMS.Shared.Commands.Contracts;

namespace BMS.Domain.Handlers
{
    public class CriaProdutoHandler
    {
        private readonly IRepository _repository;

        public CriaProdutoHandler(IRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CadastraProdutoCommand command)
        {
            //fast validation
            if(!command.Validate())
                return new GenericCommandResult(false, "ops, parece que ocorreu algum erro", command.Notificacoes);

            //verifica pelo código se o produto já existe no banco 
            //-------------- implementar --------------------

            //gera um produto
            var produto = new Produto(command.Nome, command.Codigo, command.Descricao, command.PrecoCusto, command.PrecoVenda);

            //salva no banco
            _repository.Cria(produto);

            //retorno
            return new GenericCommandResult(true, "Produto cadastrado com sucesso", command.Notificacoes);
        }
    }
}
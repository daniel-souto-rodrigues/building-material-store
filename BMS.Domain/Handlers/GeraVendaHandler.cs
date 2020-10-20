using BMS.Domain.Commands;
using BMS.Domain.Entities;
using BMS.Domain.Enums;
using BMS.Domain.Repositories.Interfaces;
using BMS.Shared.Commands;
using BMS.Shared.Commands.Contracts;
using BMS.Shared.Entities;
using BMS.Shared.Handlers.Contracts;

namespace BMS.Domain.Handlers
{
    public class GeraVendaHandler : Notificavel, IHandler<GeraVendaCommand>
    {
        private readonly IRepository _repository;

        public GeraVendaHandler(IRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(GeraVendaCommand command)
        {
            //validação rápida
            if (!command.Validate())
                return new GenericCommandResult(false, "ops, parece que algo deu errado", command.Notificacoes);

            var usuario = _repository.ProcuraUsuarioPorLogin(command.Usuario);
            if (usuario == null)
                return new GenericCommandResult(false, "O usuario passado não existe na base", command.Usuario);

            //gerar uma venda passando um usuário
            var venda = new Venda(usuario);

            //adiciona os itens da página ao carrinho
            foreach (var item in command.Itens)
            {
                var produto = _repository.ProcuraProdutoPorCodigo(item.Codigo);
                venda.AdicionaItemAoCarrinho(new VendaItem(produto, item.Quantidade));
            }

            //Calcula o total e concede desconto caso haja
            venda.ConcederDesconto(command.Desconto);

            //Recebe os pagamentos
            foreach (var pagamento in command.Pagamentos)
            {
                venda.AdicionaPagamento(new VendaPagamento(pagamento.Valor, pagamento.Tipo));
            }

            //Verifica se o Total da venda é menor que o pagamento total
            if (!venda.RealizarVenda())
            {
                command.AdicionarNotificacao("pagamento", "pagamento insuficiente para finalizar a venda!");
                return new GenericCommandResult(false, "ops, parece que algo deu errado ao finalizar a venda", command.Notificacoes);
            }

            //salva venda e fecha
            _repository.Cria(venda);
            return new GenericCommandResult(true, "venda realizada com sucesso", command);
        }
    }
}
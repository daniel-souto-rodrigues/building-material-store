using BMS.Domain.Commands;
using BMS.Domain.Entities;
using BMS.Domain.Handlers;
using BMS.Shared.Commands;
using BMS.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BMS.Tests.HandlerTests
{
    [TestClass]
    public class GeraVendaHandlerTests
    {
        [TestMethod]
        public void DadoUmComandoValidoGeraVenda()
        {
            var command = new GeraVendaCommand(new Usuario("Daniel", "123456"));
            var handler = new GeraVendaHandler(new FakeRepository());

            var result = (GenericCommandResult)handler.Handle(command);

            Assert.AreEqual(result.Sucesso, true);
        }

        [TestMethod]
        public void DadoUmComandoInvalidoNaoGeraVenda()
        {
            var command = new GeraVendaCommand(new Usuario(null, null));
            var handler = new GeraVendaHandler(new FakeRepository());

            var result = (GenericCommandResult)handler.Handle(command);

            Assert.AreEqual(result.Sucesso, false);
        }

        [TestMethod]
        public void DadoUmaVendaSemPagamentoRetornaFalse()
        {
            var command = new GeraVendaCommand(new Usuario("Daniel", "123456"));
            command.Itens.Add(new VendaItem(new Produto("martelo", 7898124565, "desc...", 10.0m, 15.0m), 2));
            var handler = new GeraVendaHandler(new FakeRepository());

            var result = (GenericCommandResult)handler.Handle(command);

            Assert.AreEqual(result.Sucesso, false);
        }

        [TestMethod]
        public void DadoUmaVendaComPagamentoRetornaTrue()
        {
            var command = new GeraVendaCommand(new Usuario("Daniel", "123456"));
            command.Itens.Add(new VendaItem(new Produto("martelo", 7898124565, "desc...", 10.0m, 15.0m), 2));
            command.Pagamentos.Add(new VendaPagamento(30.0m, Domain.Enums.EPagamentoTipo.Dinheiro));
            var handler = new GeraVendaHandler(new FakeRepository());

            var result = (GenericCommandResult)handler.Handle(command);

            Assert.AreEqual(result.Sucesso, true);
        }
    }
}

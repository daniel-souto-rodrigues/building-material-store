using BMS.Domain.Commands;
using BMS.Domain.Entities;
using BMS.Domain.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BMS.Tests.CommandTests
{
    [TestClass]
    public class GeraVendaCommandTests
    {
        private readonly Usuario _usuario = new Usuario("Daniel", "123456");
        private readonly Usuario _usuarioInvalido = new Usuario(null, null);
        private readonly GeraVendaCommand _vendaCommand;

        private Venda _novaVenda = new Venda();
        private readonly Produto _p1 = new Produto("Martelo de aço", 78921423311, "alguma desc...", 10.0m, 15.0m);
        private readonly Produto _p2 = new Produto("Furadeira", 78921423312, "alguma desc...", 100.0m, 200.0m);
        private readonly Produto _p3 = new Produto("saco de pregos c/1000 un", 78921423313, "alguma desc...", 5.0m, 10.0m);
        private readonly Produto _p4 = new Produto("Martelo de madeira", 78921423314, "alguma desc...", 10.0m, 15.0m);
        private readonly Produto _p5 = new Produto("Alicate de eletricista", 78921423315, "alguma desc...", 10.0m, 15.0m);

        private VendaItem _vi1 = new VendaItem();
        private VendaItem _vi2 = new VendaItem();
        private VendaItem _vi3 = new VendaItem();
        private VendaItem _vi4 = new VendaItem();
        private VendaItem _vi5 = new VendaItem();

        public GeraVendaCommandTests()
        {
            _vendaCommand = new GeraVendaCommand(_usuario);

            _vi1 = new VendaItem(_p1, 10);
            _vi2 = new VendaItem(_p2, 10);
            _vi3 = new VendaItem(_p3, 10);
            _vi4 = new VendaItem(_p4, 10);
            _vi5 = new VendaItem(_p5, 10);
        }

        [TestMethod]
        public void DeveRetornarSucessoAoGerarUmCommandComUsuario()
        {
            _vendaCommand.Itens.Add(_vi1);
            _vendaCommand.Itens.Add(_vi2);
            _vendaCommand.Itens.Add(_vi3);
            _vendaCommand.Itens.Add(_vi4);
            _vendaCommand.Itens.Add(_vi5);

            Assert.AreEqual(true, _vendaCommand.Validate());
        }

        [TestMethod]
        public void DeveRetornarErroAoGerarUmCommandSemUsuario()
        {
            _vendaCommand.Itens.Add(_vi1);
            _vendaCommand.Itens.Add(_vi2);
            _vendaCommand.Itens.Add(_vi3);
            _vendaCommand.Itens.Add(_vi4);
            _vendaCommand.Itens.Add(_vi5);

            _vendaCommand.Usuario = _usuarioInvalido;

            Assert.AreEqual(false, _vendaCommand.Validate());
        }

    }
}

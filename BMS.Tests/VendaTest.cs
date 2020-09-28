using System.Collections.Generic;
using BMS.Domain.Entities;
using BMS.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BMS.Tests
{
    [TestClass]
    public class VendaTest
    {
        private readonly Usuario _usuario = new Usuario("Daniel", "123456");
        private Venda _novaVenda = new Venda();
        private readonly Produto _p1 = new Produto("Martelo de aço", "78921423311", "alguma desc...", 10.0m, 15.0m);
        private readonly Produto _p2 = new Produto("Furadeira", "78921423312", "alguma desc...", 100.0m, 200.0m);
        private readonly Produto _p3 = new Produto("saco de pregos c/1000 un", "78921423313", "alguma desc...", 5.0m, 10.0m);
        private readonly Produto _p4 = new Produto("Martelo de madeira", "78921423314", "alguma desc...", 10.0m, 15.0m);
        private readonly Produto _p5 = new Produto("Alicate de eletricista", "78921423315", "alguma desc...", 10.0m, 15.0m);

        private VendaItem _vi1 = new VendaItem();
        private VendaItem _vi2 = new VendaItem();
        private VendaItem _vi3 = new VendaItem();
        private VendaItem _vi4 = new VendaItem();
        private VendaItem _vi5 = new VendaItem();

        public VendaTest()
        {
            _novaVenda = new Venda(_usuario);

            _vi1 = new VendaItem(_p1, 10);
            _vi2 = new VendaItem(_p2, 10);
            _vi3 = new VendaItem(_p3, 10);
            _vi4 = new VendaItem(_p4, 10);
            _vi5 = new VendaItem(_p5, 10);
        }

        [TestMethod]
        public void CalculaValorDaVendaMedianteItensNoCarrinho()
        {
            _novaVenda.AdicionaItemAoCarrinho(_vi1);
            _novaVenda.AdicionaItemAoCarrinho(_vi2);
            _novaVenda.AdicionaItemAoCarrinho(_vi3);
            _novaVenda.AdicionaItemAoCarrinho(_vi4);
            _novaVenda.AdicionaItemAoCarrinho(_vi5);

            _novaVenda.CalculaTotal();
            Assert.AreEqual(2550.0m, _novaVenda.Total);
        }

        [TestMethod]
        public void CalculaValorDaVendaMedianteItensRemovidosDoCarrinho()
        {
            _novaVenda.AdicionaItemAoCarrinho(_vi1);
            _novaVenda.AdicionaItemAoCarrinho(_vi2);
            _novaVenda.AdicionaItemAoCarrinho(_vi3);
            _novaVenda.AdicionaItemAoCarrinho(_vi4);
            _novaVenda.AdicionaItemAoCarrinho(_vi5);

            _novaVenda.RemoveItemDoCarrinho(_vi1);

            _novaVenda.CalculaTotal();
            Assert.AreEqual(2400.0m, _novaVenda.Total);
        }

        [TestMethod]
        public void RealizaVendaPassandoPagamentoComValorCorreto()
        {
            _novaVenda.AdicionaItemAoCarrinho(_vi1);
            _novaVenda.AdicionaItemAoCarrinho(_vi2);
            _novaVenda.AdicionaItemAoCarrinho(_vi3);
            _novaVenda.AdicionaItemAoCarrinho(_vi4);
            _novaVenda.AdicionaItemAoCarrinho(_vi5);

            _novaVenda.CalculaTotal();
            _novaVenda.AdicionaPagamento(new VendaPagamento(1500, EPagamentoTipo.Dinheiro));
            _novaVenda.AdicionaPagamento(new VendaPagamento(1050, EPagamentoTipo.Cartao));

            _novaVenda.RealizaVenda();

            Assert.AreEqual(EVendaStatus.Realizada, _novaVenda.Status);
        }

        [TestMethod]
        public void NaoRealizaVendaPassandoPagamentoComValorErrado()
        {
            _novaVenda.AdicionaItemAoCarrinho(_vi1);
            _novaVenda.AdicionaItemAoCarrinho(_vi2);
            _novaVenda.AdicionaItemAoCarrinho(_vi3);
            _novaVenda.AdicionaItemAoCarrinho(_vi4);
            _novaVenda.AdicionaItemAoCarrinho(_vi5);

            _novaVenda.CalculaTotal();
            _novaVenda.AdicionaPagamento(new VendaPagamento(1500, EPagamentoTipo.Dinheiro));
            _novaVenda.AdicionaPagamento(new VendaPagamento(1000, EPagamentoTipo.Cartao));

            _novaVenda.RealizaVenda();

            Assert.AreEqual(null, _novaVenda.Status); //adicionar validação para que
        }
    }
}

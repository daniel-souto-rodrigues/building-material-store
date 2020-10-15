using System;
using System.Collections.Generic;
using System.Linq;
using BMS.Domain.Entities;
using BMS.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BMS.Tests.QueriesTests
{
    [TestClass]
    public class QueriesTests
    {
        private Usuario _usuario;
        private Produto _produto;
        private Venda _venda;

        private readonly IList<Usuario> _usuarios;
        private readonly IList<Produto> _produtos;
        private readonly IList<Venda> _vendas;

        public QueriesTests()
        {
            _usuario = new Usuario("Daniel", "12345678");
            _produto = new Produto("Martelo de aço", 78921423311, "alguma desc...", 10.0m, 15.0m);
            _venda = new Venda(_usuario);

            _venda.Id = new Guid("b09374d0-8fb0-4cc6-8a06-90b3a2a26434");

            _produtos = new List<Produto>();
            _usuarios = new List<Usuario>();
            _vendas = new List<Venda>();

            _usuarios.Add(_usuario);
            _produtos.Add(_produto);
            _vendas.Add(_venda);
        }

        [TestMethod]
        public void DadaAConsultaDeUsuarioDeveRetornar1Resultado()
        {
            var result = _produtos.AsQueryable().Where(ProdutoQueries.ProcuraProduto(78921423311));
            Assert.AreEqual(1, result.Count());
        }
        
        [TestMethod]
        public void DadaAConsultaDeProdutoDeveRetornar1Resultado()
        {
            var result = _usuarios.AsQueryable().Where(UsuarioQueries.ProcuraUsuario("Daniel"));
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void DadaAConsultaDeUsuarioDeveRetornarOK()
        {
            var result = _vendas.AsQueryable().Where(VendaQueries.ProcuraVenda(new Guid("b09374d0-8fb0-4cc6-8a06-90b3a2a26434")));
            Assert.AreEqual(1, result.Count());
        }

    }
}
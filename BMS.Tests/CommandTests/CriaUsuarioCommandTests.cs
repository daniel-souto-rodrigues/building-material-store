using BMS.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BMS.Tests.CommandTests
{
    [TestClass]
    public class CriaUsuarioCommandTests
    {
        private readonly CriaUsuarioCommand _usuarioValido;
        private readonly CriaUsuarioCommand _usuarioInvalido;

        public CriaUsuarioCommandTests()
        {
            _usuarioValido = new CriaUsuarioCommand("Daniel", "123456");
            _usuarioInvalido = new CriaUsuarioCommand("da", "123456");
        }

        [TestMethod]
        public void DeveRetornarFalseParaUsuarioInvalido()
        {
            Assert.AreEqual(false, _usuarioInvalido.Validate());
        }

        [TestMethod]
        public void DeveRetornarTrueParaUsuarioValido()
        {
            Assert.AreEqual(true, _usuarioValido.Validate());
        }
    }
}
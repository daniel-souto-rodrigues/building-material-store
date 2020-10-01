using System;
using BMS.Domain.Entities;
using BMS.Domain.Repositories.Interfaces;

namespace BMS.Tests.Repositories
{
    public class FakeRepository : IRepository
    {
        public void Cancela(Venda venda)
        {
        }

        public void Cria(Venda venda)
        {
        }

        public void Cria(Usuario usuario)
        {
        }

        public void Cria(Produto produto)
        {
        }

        public Produto ProcuraProdutoPorCodigo(Guid id, string codigo)
        {
            return null;
        }

        public bool VerificaSeUsuarioExiste(Guid id, string login)
        {
            return true;
        }

        public Usuario ProcuraUsuarioPorCodigo(Guid id, string login)
        {
            return new Usuario(null, null);
        }

        public void Atualiza(Venda venda)
        {
        }

        public void Atualiza(Usuario usuario)
        {
        }

        public void Atualiza(Produto produto)
        {
        }
    }
}
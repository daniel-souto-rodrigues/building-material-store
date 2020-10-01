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

        public Produto ProcuraProdutoPorCodigo(string codigo)
        {
            return null;
        }
        
        public bool VerificaSeUsuarioExiste(string login)
        {
            return true;
        }

        public string ProcuraUsuarioPorCodigo(string login)
        {
            return "daniel";
        }
    }
}
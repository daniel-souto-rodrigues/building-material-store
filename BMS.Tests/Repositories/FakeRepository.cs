using System;
using System.Collections.Generic;
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

        public Usuario ProcuraUsuarioPorCodigo(string login)
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

        public List<Usuario> RetornaTodosUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}
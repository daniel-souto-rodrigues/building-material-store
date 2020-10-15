using System;
using System.Collections.Generic;
using BMS.Domain.Entities;
using BMS.Domain.Repositories.Interfaces;

namespace BMS.Tests.Repositories
{
    public class FakeRepository : IRepository
    {
        public void Atualiza(Venda venda)
        {
        }

        public void Atualiza(Usuario usuario)
        {
        }

        public void Atualiza(Produto produto)
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

        public void DeletaProduto(long codigo)
        {
        }

        public void DeletaUsuario(string login)
        {
        }

        public Produto ProcuraProdutoPorCodigo(long codigo)
        {
            return null;
        }

        public Usuario ProcuraUsuarioPorLogin(string login)
        {
             return null;
        }

        public IEnumerable<Produto> RetornaTodosProdutos()
        {
             return null;
        }

        public IEnumerable<Usuario> RetornaTodosUsuarios()
        {
             return null;
        }

        public bool VerificaSeUsuarioExiste(string login)
        {
            if(login == "Daniel")
                return true;
            return false;
        }
    }
}
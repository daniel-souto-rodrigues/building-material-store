using System;
using System.Collections.Generic;
using BMS.Domain.Entities;

namespace BMS.Domain.Repositories.Interfaces
{
    public interface IRepository
    {
        void Cria(Venda venda);
        void Atualiza(Venda venda);
        void Cria(Usuario usuario);
        void Atualiza(Usuario usuario);
        void DeletaUsuario(string login);
        void Cria(Produto produto);
        void Atualiza(Produto produto);
        void DeletaProduto(long codigo);
        Produto ProcuraProdutoPorCodigo(long codigo);
        Usuario ProcuraUsuarioPorLogin(string login);
        bool VerificaSeUsuarioExiste(string login);
        IEnumerable<Usuario> RetornaTodosUsuarios(); //test
        IEnumerable<Produto> RetornaTodosProdutos(); //test
    }
}
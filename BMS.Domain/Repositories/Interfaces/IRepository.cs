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
        void Cria(Produto produto);
        void Atualiza(Produto produto);
        Produto ProcuraProdutoPorCodigo(string codigo);
        Usuario ProcuraUsuarioPorCodigo(string login);
        bool VerificaSeUsuarioExiste(string login);
        List<Usuario> RetornaTodosUsuarios();
    }
}
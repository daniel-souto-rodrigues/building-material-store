using System;
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
        Produto ProcuraProdutoPorCodigo(Guid id, string codigo);
        Usuario ProcuraUsuarioPorCodigo(Guid id ,string login);
        bool VerificaSeUsuarioExiste(Guid id, string login);
    }
}
using System;
using BMS.Domain.Entities;

namespace BMS.Domain.Repositories.Interfaces
{
    public interface IRepository
    {
        void Cria(Venda venda);
        void Cancela(Venda venda);
        void Cria(Usuario usuario);
        void Cria(Produto produto);
        Produto ProcuraProdutoPorCodigo(string codigo); 
        string ProcuraUsuarioPorCodigo(string login);  
        bool VerificaSeUsuarioExiste(string login);    
    }
}
using System;
using System.Linq.Expressions;
using BMS.Domain.Entities;

namespace BMS.Domain.Queries
{
    public static class ProdutoQueries
    {
        public static Expression<Func<Produto, bool>> ProcuraProduto(string codigo)
        {
            return x => x.Codigo == codigo;
        }
    }
}
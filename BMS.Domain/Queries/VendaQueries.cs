using System;
using System.Linq.Expressions;
using BMS.Domain.Entities;

namespace BMS.Domain.Queries
{
    public static class VendaQueries
    {
        public static Expression<Func<Venda, bool>> ProcuraVenda(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
using System;
using System.Linq.Expressions;
using BMS.Domain.Entities;

namespace BMS.Domain.Queries
{
    public static class UsuarioQueries
    {
        public static Expression<Func<Usuario, bool>> ProcuraUsuario(string login)
        {
            return x => x.Login == login;
        }
    }
}
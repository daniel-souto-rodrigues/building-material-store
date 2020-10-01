using System;
using System.Linq;
using BMS.Domain.Entities;
using BMS.Domain.Repositories.Interfaces;
using BMS.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BMS.Infra.Repositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Atualiza(Venda venda)
        {
            _context.Entry(venda).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Atualiza(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Atualiza(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Cria(Venda venda)
        {
            _context.Add(venda);
            _context.SaveChanges();
        }

        public void Cria(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public void Cria(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
        }

        public Produto ProcuraProdutoPorCodigo(Guid id, string codigo)
        {
            //escrever a query pra isso
            return _context.Produtos.AsNoTracking().FirstOrDefault(x => x.Id == id && x.Codigo == codigo);
        }

        public Usuario ProcuraUsuarioPorCodigo(Guid id, string login)
        {
            //escrever a query pra isso
            return _context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Id == id && x.Login == login);
        }

        public bool VerificaSeUsuarioExiste(Guid id, string login)
        {
            var resultado = _context.Usuarios.FirstOrDefault(x =>x.Id == id && x.Login == login);
            return resultado == null;
        }
    }
}
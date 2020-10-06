using System;
using System.Collections.Generic;
using System.Linq;
using BMS.Domain.Entities;
using BMS.Domain.Queries;
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

        public Produto ProcuraProdutoPorCodigo(string codigo)
        {
            return _context.Produtos.AsNoTracking().FirstOrDefault(ProdutoQueries.ProcuraProduto(codigo));
        }

        public Usuario ProcuraUsuarioPorCodigo(string login)
        {
            return _context.Usuarios.AsNoTracking().FirstOrDefault(UsuarioQueries.ProcuraUsuario(login));
        }

        public bool VerificaSeUsuarioExiste(string login)
        {
            var resultado = _context.Usuarios.FirstOrDefault(UsuarioQueries.ProcuraUsuario(login));
            return resultado != null;
        }

        public List<Usuario> RetornaTodosUsuarios() //metodo teste
        {
            return _context.Usuarios.ToList();
        }
    }
}
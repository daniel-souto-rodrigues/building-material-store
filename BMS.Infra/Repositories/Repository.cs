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

            // foreach(var item in venda.Itens)
            //     _context.Add(item);            

            // foreach(var pagamento in venda.Pagamentos)
            //     _context.Add(pagamento);
            
            _context.SaveChanges();
        }

        public void Cria(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public void DeletaUsuario(string login)
        {
            var usuario = ProcuraUsuarioPorLogin(login);
            usuario.Deletado = true;
            _context.Update(usuario);
            _context.SaveChanges();
        }

        public void DeletaProduto(string codigo)
        {
            var produto = ProcuraProdutoPorCodigo(codigo);
            produto.Deletado = true;
            _context.Update(produto);
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

        public Usuario ProcuraUsuarioPorLogin(string login)
        {
            return _context.Usuarios.AsNoTracking().FirstOrDefault(UsuarioQueries.ProcuraUsuario(login));
        }

        public bool VerificaSeUsuarioExiste(string login)
        {
            var resultado = _context.Usuarios.FirstOrDefault(UsuarioQueries.ProcuraUsuario(login));
            return resultado != null;
        }

        public IEnumerable<Usuario> RetornaTodosUsuarios() //test method
        {
            return _context.Usuarios;
        }

        public IEnumerable<Produto> RetornaTodosProdutos() //test method
        {
            return _context.Produtos;
        }
    }
}
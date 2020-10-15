using System.Linq;
using BMS.Shared.Commands.Contracts;
using BMS.Shared.Entities;

namespace BMS.Domain.Commands
{
    public class CadastraProdutoCommand : Notificavel, ICommand
    {
        public CadastraProdutoCommand() { }
        public CadastraProdutoCommand(string nome, int codigo, string descricao, decimal precoCusto, decimal precoVenda)
        {
            Nome = nome;
            Codigo = codigo;
            Descricao = descricao;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
        }
        
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }

        public bool Validate()
        {
            if (Nome == null)
                AdicionarNotificacao("NomeProd", "O campo nome é obrigatório");
            if (Nome.Length < 3 || Nome.Length > 80)
                AdicionarNotificacao("NomeProd", "O nome do produto deve ter entre 3 e 80 caracteres");
            if (Codigo.ToString().Length > 24)
                AdicionarNotificacao("Codigo", "O codigo do produto pode ter no máximo 24 caracteres");
            if (PrecoCusto <= 0)
                AdicionarNotificacao("Preco", "O preço de custo não pode ficar vazio");

            return !Notificacoes.Any();
        }
    }
}
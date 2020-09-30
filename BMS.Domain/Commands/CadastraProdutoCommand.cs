using System;
using System.Linq;
using BMS.Shared.Commands.Contracts;
using BMS.Shared.Entities;

namespace BMS.Domain.Commands
{
    public class CadastraProdutoCommand : Notificavel, ICommand
    {
        public CadastraProdutoCommand() { }
        public CadastraProdutoCommand(Guid id, string nome, string codigo, string descricao, decimal precoCusto, decimal precoVenda)
        {
            Id = id;
            Nome = nome;
            Codigo = codigo;
            Descricao = descricao;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }

        public bool Validate()
        {
            if(Nome == null)
                AdicionarNotificacao("NomeProd", "O campo nome é indispensavel");
            if(Nome.Length < 3 || Nome.Length > 60)
                AdicionarNotificacao("NomeProd", "O nome do produto deve ter entre 3 e 60 caracteres");
            if(Codigo == null)
                AdicionarNotificacao("Codigo", "O campo código é indispensavel");
            if(Codigo.Length <= 20)
                AdicionarNotificacao("Codigo", "O codigo do produto pode ter no máximo 20 caracteres");

            return !Notificacoes.Any();
        }
    }
}
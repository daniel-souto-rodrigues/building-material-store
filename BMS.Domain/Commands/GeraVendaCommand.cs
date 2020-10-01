using System.Collections.Generic;
using System.Linq;
using BMS.Domain.Entities;
using BMS.Shared.Commands.Contracts;
using BMS.Shared.Entities;

namespace BMS.Domain.Commands
{
    public class GeraVendaCommand : Notificavel, ICommand
    {
        private readonly IList<VendaItem> _itens = new List<VendaItem>();
        private readonly IList<VendaPagamento> _pagamentos = new List<VendaPagamento>();
        public GeraVendaCommand() { }
        public GeraVendaCommand(string usuario)
        {
            Usuario = usuario;
            Itens = _itens;
            Pagamentos = _pagamentos;
            Total = 0;
            Desconto = 0;
        }
        public string Usuario { get; set; }
        public IList<VendaItem> Itens { get; set; }
        public IList<VendaPagamento> Pagamentos { get; set; }
        public decimal Total { get; set; }
        public decimal Desconto { get; set; }

        public bool Validate()
        {
            if (Usuario == null)
                AdicionarNotificacao("UsuarioLogin", "O usuario é requerido para efeturar uma venda");

            return !Notificacoes.Any();
        }
    }
}
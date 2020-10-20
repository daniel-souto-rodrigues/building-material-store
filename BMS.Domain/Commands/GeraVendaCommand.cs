using System;
using System.Collections.Generic;
using System.Linq;
using BMS.Domain.Entities;
using BMS.Domain.Enums;
using BMS.Shared.Commands.Contracts;
using BMS.Shared.Entities;
using BMS.Domain.ValueObjects;

namespace BMS.Domain.Commands
{
    public class GeraVendaCommand : Notificavel, ICommand
    {
        public GeraVendaCommand() { }
        public GeraVendaCommand(string usuario, ICollection<Item> itens, ICollection<Pagamento> pagamentos, decimal desconto)
        {
            Usuario = usuario;
            Itens = itens.ToList();
            Pagamentos = pagamentos.ToList();
            Desconto = desconto;
        }

        public string Usuario { get; set; }
        public decimal Desconto { get; private set; }
        public List<Item> Itens { get; set; }
        public List<Pagamento> Pagamentos { get; set; }

        public bool Validate()
        {
            if (Usuario == null)
                AdicionarNotificacao("UsuarioLogin", "O usuario é requerido para efeturar uma venda");

            return !Notificacoes.Any();
        }
    }
}

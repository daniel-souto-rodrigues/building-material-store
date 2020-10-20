using System.Collections.Generic;
using BMS.Domain.Enums;

namespace BMS.Domain.Entities
{
    public class VendaPagamento : Entity
    {
        private readonly IList<string> _notificacoes = new List<string>();
        public VendaPagamento()
        {
        }

        public VendaPagamento(decimal valor, EPagamentoTipo tipo)
        {
            Valor = valor;
            Tipo = tipo;
            Notificacoes = _notificacoes;
        }

        public decimal Valor { get; private set; }
        public decimal Troco { get; private set; }
        public EPagamentoTipo Tipo { get; private set; }
        public IList<string> Notificacoes { get; private set; }
    }
}
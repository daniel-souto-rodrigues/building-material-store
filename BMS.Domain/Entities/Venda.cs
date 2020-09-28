using System;
using System.Collections.Generic;
using BMS.Domain.Enums;

namespace BMS.Domain.Entities
{
    public class Venda : Entity
    {
        private readonly IList<VendaItem> _itens = new List<VendaItem>();
        private readonly IList<VendaPagamento> _pagamentos = new List<VendaPagamento>();

        public Venda()
        {
        }

        public Venda(Usuario usuario)
        {
            Desconto = 0;
            DataDaVenda = DateTime.Now;
            Usuario = usuario;
            Itens = _itens;
            Pagamentos = _pagamentos;
        }

        public decimal Total { get; private set; }
        public decimal Desconto { get; private set; }
        public DateTime DataDaVenda { get; private set; }
        public Usuario Usuario { get; private set; }
        public EVendaStatus Status { get; private set; }
        public IList<VendaItem> Itens { get; private set; }
        public IList<VendaPagamento> Pagamentos { get; private set; }

        public void AdicionaItemAoCarrinho(VendaItem item)
        {
            Itens.Add(item);
        }

        public void RemoveItemDoCarrinho(VendaItem item)
        {
            Itens.Remove(item);
        }

        public void ConcederDesconto(decimal desconto)
        {
            Desconto = desconto;
        }

        public void AdicionaPagamento(VendaPagamento pagamento)
        {
            Pagamentos.Add(pagamento);
        }

        public void RealizaVenda()
        {
            decimal soma = 0;
            foreach (VendaPagamento pagamento in Pagamentos)
            {
                soma += pagamento.Valor;
            }

            if (soma >= Total)
                Status = EVendaStatus.Realizada;
        }

        public void CancelaVenda()
        {
            Status = EVendaStatus.Cancelada;
        }

        public void CalculaTotal()
        {
            decimal soma = 0;
            foreach (VendaItem item in Itens)
            {
                soma += item.Valor;
            }

            Total = soma - Desconto;
        }


    }
}
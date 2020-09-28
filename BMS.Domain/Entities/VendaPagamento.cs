using BMS.Domain.Enums;

namespace BMS.Domain.Entities
{
    public class VendaPagamento : Entity
    {
        public VendaPagamento()
        {
        }

        public VendaPagamento(decimal valor, EPagamentoTipo tipo)
        {
            Valor = valor;
            Tipo = tipo;
        }

        public decimal Valor { get; private set; }
        public decimal Troco { get; private set; }
        public EPagamentoTipo Tipo { get; private set; }

        public void CalculaTroco(decimal valorVenda)
        {
            Troco = valorVenda - Valor;
        }
    }
}
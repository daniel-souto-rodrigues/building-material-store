using BMS.Domain.Enums;

namespace BMS.Domain.ValueObjects
{
    public class Pagamento
    {
        public EPagamentoTipo Tipo { get; set; }
        public decimal Valor { get; set; }
    }
}
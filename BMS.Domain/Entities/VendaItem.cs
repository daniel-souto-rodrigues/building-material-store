namespace BMS.Domain.Entities
{
    public class VendaItem : Entity
    {
        public VendaItem()
        {
        }
        
        public VendaItem(Produto produto, decimal quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
            Valor = produto.PrecoVenda * quantidade;
        }

        public decimal Quantidade { get; private set; }
        public decimal Valor { get; private set; }
        public Produto Produto { get; private set; }

        public void AtualizaQuantidade(Produto produto ,int qtAtualizada)
        {
            if(Produto.Equals(produto))
                Quantidade = qtAtualizada;
        }
    }
}
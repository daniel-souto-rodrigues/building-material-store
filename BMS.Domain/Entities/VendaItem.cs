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
            ProdutoCodigo = produto.Codigo;
        }

        public decimal Quantidade { get; private set; }
        public decimal Valor { get; private set; }
        public virtual Produto Produto { get; private set; }
        public string ProdutoCodigo { get; private set; }

        public void AtualizaQuantidade(int qtAtualizada)
        {
            Quantidade = qtAtualizada;
        }
    }
}
namespace BMS.Domain.Entities
{
    public class Produto
    {
        public Produto(){}
        public Produto(string nome, long codigo, string descricao, decimal precoCusto, decimal precoVenda)
        {
            Nome = nome;
            Codigo = codigo;
            Descricao = descricao;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
        }

        public string Nome { get; private set; }
        public long Codigo { get; private set; }
        public string Descricao{ get; private set; }
        public decimal PrecoCusto { get; private set; }
        public decimal PrecoVenda { get; private set; }
    }
}



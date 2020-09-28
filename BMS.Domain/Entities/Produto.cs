namespace BMS.Domain.Entities
{
    public class Produto : Entity
    {
        public Produto(string nome, string codigo, string descricao, decimal precoCusto, decimal precoVenda)
        {
            Nome = nome;
            Codigo = codigo;
            Descricao = descricao;
            PrecoCusto = precoCusto;
            PrecoVenda = precoVenda;
        }

        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public string Descricao{ get; private set; }
        public decimal PrecoCusto { get; private set; }
        public decimal PrecoVenda { get; private set; }
    }
}
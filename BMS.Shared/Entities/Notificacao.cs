namespace BMS.Shared.Entities
{
    public sealed class Notificacao
    {
        public Notificacao(string propriedade, string mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;
        }

        public string Propriedade { get; private set; }
        public string Mensagem { get; private set; }

    }
}
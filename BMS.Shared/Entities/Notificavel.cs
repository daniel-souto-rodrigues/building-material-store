using System.Collections.Generic;
using System.Linq;

namespace BMS.Shared.Entities
{
    public abstract class Notificavel
    {
        private readonly List<Notificacao> _notificacoes;
        public IReadOnlyCollection<Notificacao> Notificacoes => _notificacoes;
        protected Notificavel()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void AdicionarNotificacao(string propriedade, string mensagem)
        {
            _notificacoes.Add(new Notificacao(propriedade, mensagem));
        }

        public void AdicionarNotificacoes(IReadOnlyCollection<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }
        public void AdicionarNotificacoes(ICollection<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }
        public void AdicionarNotificacoes(IList<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }
        public void AdicionarNotificacoes(Notificavel item)
        {
            AdicionarNotificacoes(item.Notificacoes);
        }

        public void AdicionarNotificacoes(params Notificavel[] itens)
        {
            foreach(var item in itens)
                AdicionarNotificacoes(item);
        }
        
        public void LimpaNotificacoes()
        {
            _notificacoes.Clear();
        }

        public bool Invalid => _notificacoes.Any();
        public bool Valid => !Invalid;
    }
}
using System.Linq;
using BMS.Shared.Commands.Contracts;
using BMS.Shared.Entities;

namespace BMS.Domain.Commands
{
    public class CriaUsuarioCommand : Notificavel, ICommand 
    {
        public CriaUsuarioCommand() { }
        public CriaUsuarioCommand(string login, string senha)
        {
            this.Login = login;
            this.Senha = senha;
        }
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool Validate()
        {            
            if(Login == null)
                AdicionarNotificacao("Login","O login é obrigatório");
            if(Login.Length < 3 || Login.Length > 30)
                AdicionarNotificacao("Login","O login precisa ter no mínimo 3 e no máximo 30 caracteres");
            if(Senha == null)
                AdicionarNotificacao("Senha","A senha é obrigatória");
            if(Senha.Length < 6 || Senha.Length > 10)
                AdicionarNotificacao("Senha","A senha precisa ter no mínimo 6 e no máximo 10 caracteres");

            return !Notificacoes.Any();
        }
    }
}
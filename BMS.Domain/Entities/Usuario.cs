namespace BMS.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }

        public string Login { get; private set; }
        public string Senha { get; private set; }
    }
}
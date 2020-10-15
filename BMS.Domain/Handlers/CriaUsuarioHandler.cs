using BMS.Domain.Commands;
using BMS.Domain.Entities;
using BMS.Domain.Repositories.Interfaces;
using BMS.Shared.Commands;
using BMS.Shared.Commands.Contracts;
using BMS.Shared.Entities;
using BMS.Shared.Handlers.Contracts;

namespace BMS.Domain.Handlers
{
    public class CriaUsuarioHandler : Notificavel, IHandler<CriaUsuarioCommand>
    {
        private readonly IRepository _repository;

        public CriaUsuarioHandler(IRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CriaUsuarioCommand command)
        {
            //validação rapida
            if(!command.Validate())
                return new GenericCommandResult(false, "ops, parece que algo deu errado", command.Notificacoes);
            
            //passa o usuario
            var usuario = new Usuario(command.Login, command.Senha);

            //valida se já existe o login no banco
            if(_repository.VerificaSeUsuarioExiste(command.Login))
                return new GenericCommandResult(false, "O usuario já tem cadastro na base", command.Notificacoes);

            //salva o usuario
            _repository.Cria(usuario);

            //retorna sucesso
            return new GenericCommandResult(true, "usuario cadastrado com sucesso", command);
        }
    }
}
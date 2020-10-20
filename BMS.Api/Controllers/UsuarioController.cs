using System.Collections.Generic;
using BMS.Domain.Commands;
using BMS.Domain.Entities;
using BMS.Domain.Repositories.Interfaces;
using BMS.Shared.Commands;
using BMS.Shared.Handlers.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BMS.Api.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UsuarioController : ControllerBase
    {
        private readonly IHandler<CriaUsuarioCommand> _handler;
        private readonly IRepository _repository;

        public UsuarioController(
        IHandler<CriaUsuarioCommand> handler,
        IRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        [Route("")]
        public GenericCommandResult CriaUsuario([FromBody] CriaUsuarioCommand command)
        {
            return (GenericCommandResult)_handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public GenericCommandResult RetornaUsuario([FromBody] string login)
        {
            var usuario = _repository.ProcuraUsuarioPorLogin(login);

            if (usuario == null)
                return new GenericCommandResult(false, "não existe usuario com este login na base de dados", login);

            usuario.EscondeSenha();
            return new GenericCommandResult(true, "usuario encontrado com sucesso", usuario);
        }

        [Route("{login}")]
        [HttpPut]
        public GenericCommandResult AtualizaUsuario(string login, [FromBody] CriaUsuarioCommand command)
        {
            if (_repository.ProcuraUsuarioPorLogin(login) == null)
                return new GenericCommandResult(false, "usuario não encontrado na base", login);
            if (!command.Validate())
                return new GenericCommandResult(false, "ops parece que algo deu errado", command.Notificacoes);
            else
            {
                var usuario = _repository.ProcuraUsuarioPorLogin(login);
                usuario.AtualizaDados(command.Login, command.Senha);
                _repository.Atualiza(usuario);
                usuario.EscondeSenha();
                return new GenericCommandResult(true, "usuario atualizado com sucesso!", usuario);
            }
        }

        [Route("")]
        [HttpDelete]
        public GenericCommandResult DeletaUsuario([FromBody] string login)
        {
            var usuario = _repository.ProcuraUsuarioPorLogin(login);
            if (usuario == null)
                return new GenericCommandResult(false, "usuario nao encontrado na base", login);
            if (usuario.Deletado == true)
            {
                usuario.EscondeSenha();
                return new GenericCommandResult(false, "usuario já foi deletado", usuario);
            }

            _repository.DeletaUsuario(login);
            usuario = _repository.ProcuraUsuarioPorLogin(login);
            usuario.EscondeSenha();
            return new GenericCommandResult(true, "usuario deletado da base de dados", usuario);
        }

        /*  test method  */
        [Route("all")]
        [HttpGet]
        public IEnumerable<Usuario> RetornaUsuarios()
        {
            return _repository.RetornaTodosUsuarios();
        }
        /* ------------- */
    }
}
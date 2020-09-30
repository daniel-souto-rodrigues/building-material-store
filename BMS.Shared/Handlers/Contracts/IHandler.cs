using BMS.Shared.Commands.Contracts;

namespace BMS.Shared.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
using BMS.Shared.Entities;

namespace BMS.Shared.Commands.Contracts
{
    public interface ICommand
    {
        bool Validate();
    }
}
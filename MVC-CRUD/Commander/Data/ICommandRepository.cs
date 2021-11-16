using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommandRepository
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int Id);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);
        void DeleteCommand(Command command);
    }

}
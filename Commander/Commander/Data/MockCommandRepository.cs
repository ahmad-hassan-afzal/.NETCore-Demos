using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommandRepository : ICommandRepository
    {
        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id=1, HowTo="List All", Line="ls -a", Platform="Linux" },
                new Command { Id=2, HowTo="Change Folder", Line="cd", Platform="Linux" },
                new Command { Id=3, HowTo="List All", Line="dir", Platform="Windows" },
                new Command { Id=4, HowTo="Change Folder", Line="cd", Platform="Windows" }
            };
            return commands;
        }

        public Command GetCommandById(int Id)
        {
            return new Command
            {
                Id=1, HowTo="List All", Line="ls -a", Platform="Linux"
            };
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}
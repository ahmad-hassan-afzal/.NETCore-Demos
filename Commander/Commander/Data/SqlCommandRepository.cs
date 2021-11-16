using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class SqlCommandRepository : ICommandRepository
    {
        private readonly CommandDbContext _context;

        public SqlCommandRepository(CommandDbContext context)
        {
            this._context = context;
        }

        public void CreateCommand(Command command)
        {
            if(command == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _context.Add(command);
                _context.SaveChanges();
            }
        }

        public void DeleteCommand(Command command)
        {
            if(command == null)
            {
                throw new ArgumentNullException();
            }
            _context.Remove(command);
            _context.SaveChanges();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int Id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == Id);
        }

        public void UpdateCommand(Command command)
        {
            // Mapper in Controller.Update() will update the data so here we just need to save changes
            _context.SaveChanges();

        }
    }
}

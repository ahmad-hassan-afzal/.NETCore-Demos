using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Project.Command
{
    public class CommandProjectRepository :  ICommandProjectRepository
    {

        private readonly CommandContext _context;
        private readonly DbSet<Core.Project> _projects;
        public CommandProjectRepository(CommandContext context)
        {
            _context = context;
            _projects = context.Projects;
        }

        public Core.Project Add(Core.Project project)
        {
            _projects.Add(project);
            return project;
        }

        public Core.Project Delete(Core.Project project)
        {
            _projects.Remove(project);
            return project;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Core.Project Update(Core.Project ProjectChanges)
        {
            var proj = _projects.Attach(ProjectChanges);
            proj.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return ProjectChanges;
        }

    }
}

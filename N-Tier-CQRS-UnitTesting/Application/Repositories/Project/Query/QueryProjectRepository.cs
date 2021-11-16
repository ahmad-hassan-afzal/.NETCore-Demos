using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.Repositories.Project.Query
{
    public class QueryProjectRepository :  IQueryProjectRepository
    {
        private readonly QueryContext _context;
        private readonly DbSet<Core.Project> _projects;
        public QueryProjectRepository(QueryContext context)
        {
            _context = context;
            _projects = context.Projects;
        }


        public IEnumerable<Core.Project> GetAllProjects()
            => _projects.ToList();


        public Core.Project GetProject(int ProjectId)
            => _projects.Find(ProjectId);

        public IEnumerable<Core.Project> GetByCompanyId(int companyId)
        {
            return _projects.Where(x => x.CompanyId == companyId);
        }
    }
}

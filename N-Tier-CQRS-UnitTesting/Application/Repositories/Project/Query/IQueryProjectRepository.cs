using Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repositories.Project.Query
{
    public interface IQueryProjectRepository :  IBaseRepository
    {
        IEnumerable<Core.Project> GetAllProjects();
        IEnumerable<Core.Project> GetByCompanyId(int companyId);
        Core.Project GetProject(int Id);
    }
}

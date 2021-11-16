using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Project.Command
{
    public interface ICommandProjectRepository : IBaseCommandRepository
    {
        Core.Project Add(Core.Project project);
        Core.Project Update(Core.Project project);
        Core.Project Delete(Core.Project project);

    }
}

using Application.Repositories;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Company.Command
{
    public interface ICommandCompanyRepository : IBaseCommandRepository
    {
        Core.Company Add(Core.Company Company);
        Core.Company Update(Core.Company Company);
        Core.Company Delete(Core.Company Company);
    }
}

using Infrastructure;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IBaseCommandRepository: IBaseRepository
    {
        public void SaveChanges();
    }
    public interface IBaseRepository
    {
        
    }
}


using Application.Repositories.Company.DTOs;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Company.Command
{
    class CommandCompanyRepository :  ICommandCompanyRepository
    {
        private readonly CommandContext _context;
        private readonly DbSet<Core.Company> _companies;
        public CommandCompanyRepository(CommandContext context)  {
            _context = context;
            _companies = context.Company;
        }

        public Core.Company Add(Core.Company Company)
        {
            _companies.Add(Company);
            return Company;
        }

        // Use Mapper here not in controller

        //public CompanyDetailsDTO Add(CompanyReadDTO dto)
        //{
        //    var model = _mapper.Map<Core.Company>(dto);
        //    _companies.Add(model);
        //    _context.SaveChanges();
        //    return _mapper.Map<CompanyDetailsDTO>(model);
        //}

        public Core.Company Delete(Core.Company Company)
        {
            _companies.Remove(Company);
            return Company;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Core.Company Update(Core.Company CompanyChanges)
        {
            _companies.Update(CompanyChanges);
            return CompanyChanges;
        }
    }
}

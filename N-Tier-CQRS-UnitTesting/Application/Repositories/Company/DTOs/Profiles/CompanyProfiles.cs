using Application.Repositories.Company.DTOs;
using Application.Repositories.Project.DTOs;
using AutoMapper;
using Core;

namespace Application.Repositories.Company.DTOs.Profiles
{
    class CompanyProfiles : Profile
    {
        public CompanyProfiles()
        {
            #region Company Profiles
            CreateMap<CompanyDetailsDTO, Core.Company>();
            CreateMap<CompanyReadDTO, Core.Company>().ReverseMap();
            #endregion

        }
    }
}

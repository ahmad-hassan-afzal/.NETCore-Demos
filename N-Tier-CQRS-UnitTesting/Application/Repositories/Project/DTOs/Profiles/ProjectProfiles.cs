using Application.Repositories.Company.DTOs;
using Application.Repositories.Project.DTOs;
using AutoMapper;
using Core;

namespace Application.Repositories.Project.DTOs.Profiles
{
    class ProjectProfiles : Profile
    {
        public ProjectProfiles()
        {
            #region Project Profiles
            CreateMap<ProjectDetailsDTO, Core.Project>();
            CreateMap<ProjectReadDTO, Core.Project>();
            CreateMap<Core.Project, ProjectDetailsDTO>();
            #endregion

        }
    }
}

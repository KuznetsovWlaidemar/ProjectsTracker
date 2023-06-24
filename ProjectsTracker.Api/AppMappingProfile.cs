using AutoMapper;
using ProjectsTracker.Api.Dto.Employees;
using ProjectsTracker.Api.Dto.Projects;
using ProjectsTracker.Domain.Employees;
using ProjectsTracker.Domain.Projects;

namespace ProjectsTracker.Api
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}

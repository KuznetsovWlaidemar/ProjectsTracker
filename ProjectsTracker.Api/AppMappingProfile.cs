using AutoMapper;
using ProjectsTracker.Api.Contracts;
using ProjectsTracker.Api.Contracts.Employee;
using ProjectsTracker.Api.Contracts.Problem;
using ProjectsTracker.Api.Contracts.Project;
using ProjectsTracker.Domain.Models;

namespace ProjectsTracker.Api
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Project, CreateProjectRequest>().ReverseMap();
            CreateMap<Project, UpdateProjectRequest>().ReverseMap();

            CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeRequest>().ReverseMap();

            CreateMap<Problem, CreateProblemRequest>().ReverseMap();
        }
    }
}

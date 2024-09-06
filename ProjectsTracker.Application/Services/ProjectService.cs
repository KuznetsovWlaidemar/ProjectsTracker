using AutoMapper;
using ProjectsTracker.Domain.Filters;
using ProjectsTracker.Domain.Models;
using ProjectsTracker.Domain.Repositories;

namespace ProjectsTracker.Application.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<IEnumerable<Project>> GetProjectsAsync(Filter filter);
        Task<Project> GetProjectAsync(int id);
        Task CreateAsync(Project project);
        Task<Project> UpdateAsync(int id, Project updatedProject);
        Task DeleteAsync(Project project);
        Task DeleteEmployeeFromProjectAsync(int problemId, int projectId);
        Task DeleteProblemFromProjectAsync(int problemId, int projectId);
    }

    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(
            IProjectRepository projectRepository,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(Project project)
        {
            await _projectRepository.CreateAsync(project);
        }

        public Task DeleteAsync(Project project)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployeeFromProjectAsync(int problemId, int projectId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProblemFromProjectAsync(int problemId, int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetProjectAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetProjectsAsync(Filter filter)
        {
            throw new NotImplementedException();
        }

        public Task<Project> UpdateAsync(int id, Project updatedProject)
        {
            throw new NotImplementedException();
        }
    }

}

using ProjectsTracker.Domain.Filters;
using ProjectsTracker.Domain.Models;

namespace ProjectsTracker.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task CreateAsync(Project project);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<IEnumerable<Project>> GetProjectsAsync(Filter filter);
        Task<Project> GetProjectAsync(int projectId);
    }
}

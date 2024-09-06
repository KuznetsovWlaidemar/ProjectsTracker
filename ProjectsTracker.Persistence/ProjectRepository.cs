using Microsoft.EntityFrameworkCore;
using ProjectsTracker.Domain.Filters;
using ProjectsTracker.Domain.Models;
using ProjectsTracker.Domain.Repositories;

namespace ProjectsTracker.Persistence
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProjectRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _appDbContext.Projects.ToListAsync();
        }
        public async Task<IEnumerable<Project>> GetProjectsAsync(Filter filter)
        {
            var query = _appDbContext.Projects.AsQueryable()
                                              .ApplyNameFilter(filter.Name)
                                              .ApplyDateFilter(filter.StartDate, filter.EndDate)
                                              .ApplyPriorityFilter(filter.Priority);
            return await query.ToListAsync();
        }
        public async Task<Project> GetProjectAsync(int projectId)
        {
            return await _appDbContext.Projects.FirstOrDefaultAsync(p => p.ProjectId == projectId);
        }

        public async Task CreateAsync(Project project)
        {
            await _appDbContext.Projects.AddAsync(project);
        }
    }
}

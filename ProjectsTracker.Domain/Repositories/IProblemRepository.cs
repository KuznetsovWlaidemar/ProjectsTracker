using ProjectsTracker.Domain.Models;

namespace ProjectsTracker.Domain.Stores
{
    public interface IProblemRepository
    {
        Task<Problem> GetByIdAsync(int id);
        Task<Problem> GetByName(string name);
        Task Add(Problem problem);
    }
}

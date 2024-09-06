using ProjectsTracker.Domain.Models;
using ProjectsTracker.Domain.Stores;

namespace ProjectsTracker.Persistence
{
    public class ProblemRepository : IProblemRepository
    {
        public Task Add(Problem problem)
        {
            throw new NotImplementedException();
        }

        public Task<Problem> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Problem> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

using ProjectsTracker.Domain.Models;

namespace ProjectsTracker.Domain.Filters
{
    public static class ProblemFilterSerivce
    {
        public static IQueryable<Problem> ApplyStatusFilter(this IQueryable<Problem> problems, TaskStatus? taskStatus)
        {
            if (taskStatus == null)
            {
                return problems;
            }
            return problems.Where(w => w.Status == taskStatus);
        }
    }
}

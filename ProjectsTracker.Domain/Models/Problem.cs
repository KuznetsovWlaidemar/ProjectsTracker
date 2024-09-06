namespace ProjectsTracker.Domain.Models
{
    public class Problem
    {
        public int ProblemId { get; set; }
        public string ProblemName { get; set; }
        public Employee Author { get; set; }
        public Employee Assignee { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        public int Priority { get; set; }
    }
}

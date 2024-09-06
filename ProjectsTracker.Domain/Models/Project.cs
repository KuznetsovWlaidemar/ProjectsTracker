namespace ProjectsTracker.Domain.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        /// <summary>
        /// Компания-заказчик
        /// </summary>
        public Company CustomerCompany { get; set; }
        /// <summary>
        /// Компания-исполнитель
        /// </summary>
        public Company ExecutorCompany { get; set; }
        public Employee ProjectManager { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Problem> Problems { get; set; }
    }
}

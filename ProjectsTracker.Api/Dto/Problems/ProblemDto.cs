using ProjectsTracker.Domain.Employees;

namespace ProjectsTracker.Api.Dto.Problems
{
    /// <summary>
    /// Промежуточный класс Задачи
    /// </summary>
    public class ProblemDto
    {
        /// <summary>
        /// Идетификатор задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименвоание задачи
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Автор задачи
        /// </summary>
        public Employee Author { get; set; }

        /// <summary>
        /// Исполнитель задачи
        /// </summary>
        public Employee Assignee { get; set; }

        /// <summary>
        /// Статус задачи
        /// </summary>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// Комментарий к задаче
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Приоритет задачи
        /// </summary>
        public int Priority { get; set; }
    }
}

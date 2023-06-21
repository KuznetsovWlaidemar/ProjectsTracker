using ProjectsTracker.Domain.Employees;

namespace ProjectsTracker.Domain.Projects
{
    /// <summary>
    /// Проект
    /// </summary>
    public class Project
    {
        #region Fields
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Компания-заказчик
        /// </summary>
        public string CustomerCompany { get; set; }

        /// <summary>
        /// Компания-исполнитель
        /// </summary>
        public string ExecutorCompany { get; set; }

        /// <summary>
        /// Дата начала проекта
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания проекта
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Приоритет проекта
        /// </summary>
        public int Priority { get; set; }
        #endregion

        #region Relationships
        /// <summary>
        /// Сотрудники проекта
        /// </summary>
        public ICollection<Employee> Employees { get; set; }
        #endregion
    }
}

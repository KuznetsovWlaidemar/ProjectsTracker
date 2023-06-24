using ProjectsTracker.Domain.Projects;

namespace ProjectsTracker.Domain.Employees
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        #region Fields
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }

        #endregion

        #region Relationships
        /// <summary>
        /// Проекты сотрудника
        /// </summary>
        public ICollection<Project> Projects { get; set; }

        #endregion
    }
}

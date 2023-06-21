using ProjectsTracker.Domain.Projects;

namespace ProjectsTracker.Domain.Employees
{
    /// <summary>
    /// Промежуточный класс Сотрудника
    /// </summary>
    public class EmployeeDto
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

        /// <summary>
        /// Роль сотрудника на проекте
        /// </summary>
        public Role Role { get; set; }

        #endregion

        #region Relationships
        /// <summary>
        /// Проекты сотрудника
        /// </summary>
        public ICollection<Project> Projects { get; set; }

        #endregion
    }
}

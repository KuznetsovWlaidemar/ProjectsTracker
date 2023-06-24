using ProjectsTracker.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTracker.Api.Dto.Projects
{
    /// <summary>
    /// Промежуточный класс для проекта
    /// </summary>
    public class ProjectDto
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

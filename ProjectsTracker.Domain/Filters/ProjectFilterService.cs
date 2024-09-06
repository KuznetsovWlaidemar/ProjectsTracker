using ProjectsTracker.Domain.Models;

namespace ProjectsTracker.Domain.Filters
{
    public static class ProjectFilterService
    {
        /// <summary>
        /// Фильтрация по имени
        /// </summary>
        /// <param name="projects">Проекты</param>
        /// <param name="name">Наименование проекта</param>
        /// <returns>Проекты</returns>
        public static IQueryable<Project> ApplyNameFilter(this IQueryable<Project> projects, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return projects;
            }
            return projects.Where(w => w.ProjectName == name);
        }

        /// <summary>
        /// Фильтрация по дате начала проекта
        /// </summary>
        /// <param name="projects">Проекты</param>
        /// <param name="startDate">Дата начала проекта</param>
        /// <returns>Проекты</returns>
        public static IQueryable<Project> ApplyStartDateFilter(this IQueryable<Project> projects, DateTime? startDate)
        {
            if (startDate is null)
            {
                return projects;
            }
            return projects.Where(w => w.StartDate == startDate);
        }

        /// <summary>
        /// Фильтрация по дате окончания проекта
        /// </summary>
        /// <param name="projects">Проекты</param>
        /// <param name="startDate">Дата окончания проекта</param>
        /// <returns>Проекты</returns>
        public static IQueryable<Project> ApplyEndDateFilter(this IQueryable<Project> projects, DateTime? endDate)
        {
            if (endDate is null)
            {
                return projects;
            }
            return projects.Where(w => w.EndDate == endDate);
        }

        /// <summary>
        /// Фильтрация по диапозону дат
        /// </summary>
        /// <param name="projects">Проекты</param>
        /// <param name="startDate">Дата начала проекта</param>
        /// <param name="endDate">Дата окончания проекта</param>
        /// <returns>Проекты</returns>
        public static IQueryable<Project> ApplyDateFilter(this IQueryable<Project> projects, DateTime? startDate, DateTime? endDate)
        {
            if (startDate is null || endDate is null)
            {
                return projects;
            }
            return projects.Where(w => w.StartDate >= startDate && w.EndDate <= endDate);
        }

        /// <summary>
        /// Фильтрация по приоритету
        /// </summary>
        /// <param name="projects">Проекты</param>
        /// <param name="priority">Приоритет</param>
        /// <returns></returns>
        public static IQueryable<Project> ApplyPriorityFilter(this IQueryable<Project> projects, int? priority)
        {
            if (priority is null)
            {
                return projects;
            }
            return projects.Where(w => w.Priority == priority);
        }

    }

}

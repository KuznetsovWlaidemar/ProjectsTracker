using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using ProjectsTracker.Api.Filter;
using ProjectsTracker.Domain.Employees;
using ProjectsTracker.Domain.Problems;
using ProjectsTracker.Domain.Projects;

namespace ProjectsTracker.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetProjects(Filter filter);
        Project GetProject(int id);
        Project CreateProject(Project project);
        Project UpdateProject(int id, Project updatedProject);
        void DeleteProject(Project project);
        void DeleteEmployeeFromProject(int problemId, int projectId);
        void DeleteProblemFromProject(int problemId, int projectId);

    }

    public class ProjectService : IProjectService
    {
        #region Fields
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ProjectService(DbContext dbContext,
                              IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Получить все проекты
        /// </summary>
        /// <param name="filter">Фильтр по полям</param>
        /// <returns>Проекты</returns>
        public IEnumerable<Project> GetProjects(Filter filter)
        {
            try
            {
                var projects = _dbContext.Projects.AsQueryable()
                                                  .ApplyNameFilter(filter.Name)
                                                  .ApplyStartDateFilter(filter.StartDate)
                                                  .ApplyEndDateFilter(filter.EndDate)
                                                  .ApplyPriorityFilter(filter.Priority)
                                                  .ToList();
                return projects;
            }
            catch
            {
                throw new Exception("Произошла ошибка при извлечении проектов");
            }
        }

        /// <summary>
        /// Получить проект по Id
        /// </summary>
        /// <param name="id">Id проекта</param>
        /// <returns>Проект</returns>
        public Project GetProject(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            if(project == null)
            {
                throw new Exception("Проект не найден");
            }
            return project;
        }

        /// <summary>
        /// Создать новый проект
        /// </summary>
        /// <param name="project">Проект</param>
        /// <returns>Проект</returns>
        public Project CreateProject(Project project)
        {
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            return project;
        }

        /// <summary>
        /// Изменить проект
        /// </summary>
        /// <param name="id">Id проекта</param>
        /// <param name="updatedProject">Данные для обновления</param>
        /// <returns></returns>
        public Project UpdateProject(int id, Project updatedProject)
        {
            try
            {
                var existingProject = GetProject(id);
               
                _mapper.Map(updatedProject, existingProject);
                _dbContext.SaveChanges();
                return existingProject;
            }
            catch
            {
                throw new Exception("Произошла ошибка при изменении проекта.");
            }
        }

        /// <summary>
        /// Удалить проект
        /// </summary>
        /// <param name="project">Проект</param>
        public void DeleteProject(Project project)
        {
            _dbContext.Projects.Remove(project);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Удалить сотрудника из проекта
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        public void DeleteEmployeeFromProject(int employeeId, int projectId)
        {
            var project = _dbContext.Projects.Where(w => w.Employees.Any(e => e.Id == employeeId) && w.Id == projectId).FirstOrDefault();
            project.Employees.Remove(new Employee { Id = employeeId });
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Удалить задачу из проекта
        /// </summary>
        /// <param name="problem">Задача</param>
        public void DeleteProblemFromProject(int problemId, int projectId)
        {
            var project = _dbContext.Projects.Where(w => w.Problems.Any(e => e.Id == problemId) && w.Id == projectId).FirstOrDefault();
            project.Problems.Remove(new Problem { Id = problemId });
            _dbContext.SaveChanges();
        }

        #endregion

    }

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

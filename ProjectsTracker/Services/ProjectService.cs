using ProjectsTracker.Domain;

namespace ProjectsTracker.Services
{
    public interface IProjectService
    {   
        IEnumerable<Employee>? GetProjects();
        Employee? GetProject(int id);
        Employee? CreateProject(Employee project);
        Employee? UpdateProject(int id, Employee updatedProject);
        int DeleteProject(int id);

    }

    public class ProjectService : IProjectService
    {
        #region Fields
        private readonly DbContext _dbContext;
        #endregion

        #region Constructors
        public ProjectService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Извлекает все проекты
        /// </summary>
        /// <returns>Все проекты</returns>
        public IEnumerable<Employee>? GetProjects()
        {
            try
            {
                var projects = _dbContext.Projects.ToList();
                return projects;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, запись в лог или возврат специального значения
                Console.WriteLine("Произошла ошибка при извелечении проектов: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Извлекает проект по Id
        /// </summary>
        /// <param name="id">Id проекта</param>
        /// <returns>Найденный проект</returns>
        public Employee? GetProject(int id)
        {
            try
            {
                var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);

                return project;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, запись в лог или возврат специального значения
                Console.WriteLine("Произошла ошибка при извелечении проекта: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Создаёт новый проект
        /// </summary>
        /// <param name="project">Создаваемый проект</param>
        /// <returns>Созданный проект</returns>
        public Employee? CreateProject(Employee project)
        {
            try
            {
                _dbContext.Projects.Add(project);
                _dbContext.SaveChanges();
                return project;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, запись в лог или возврат специального значения
                Console.WriteLine("Произошла ошибка при создании проекта: " + ex.Message);
                return null;
            }

        }
        /// <summary>
        /// Изменяет проект 
        /// </summary>
        /// <param name="id">Id проекта</param>
        /// <param name="updatedProject">Данные для обновления</param>
        /// <returns></returns>
        public Employee? UpdateProject(int id, Employee updatedProject)
        {
            try
            {
                var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
                project = updatedProject;

                _dbContext.SaveChanges();
                return project;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, запись в лог или возврат специального значения
                Console.WriteLine("Произошла ошибка при изменении проекта: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Удаляет проект по Id
        /// </summary>
        /// <param name="id">Id проекта</param>
        /// <returns>Статус код</returns>
        public int DeleteProject(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                return 1;

            _dbContext.Projects.Remove(project);
            _dbContext.SaveChanges();
            return 0;
        }
        #endregion

    }
}

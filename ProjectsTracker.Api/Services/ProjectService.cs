using AutoMapper;
using ProjectsTracker.Domain.Projects;

namespace ProjectsTracker.Services
{
    public interface IProjectService
    {   
        IEnumerable<ProjectDto> GetProjects();
        ProjectDto GetProject(int id);
        ProjectDto CreateProject(ProjectDto project);
        ProjectDto UpdateProject(int id, ProjectDto updatedProject);
        int DeleteProject(int id);

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
        /// Извлекает все проекты
        /// </summary>
        /// <returns>Все проекты</returns>
        public IEnumerable<ProjectDto> GetProjects()
        {
            try
            {
                var projects = _dbContext.Projects.ToList();
                var projectsDto = _mapper.Map<IEnumerable<ProjectDto>>(projects);
                return projectsDto;
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
        public ProjectDto GetProject(int id)
        {
            try
            {
                var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
                var projectsDto = _mapper.Map<ProjectDto>(project);
                return projectsDto;
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
        public ProjectDto CreateProject(ProjectDto projectDto)
        {
            try
            {
                var project = _mapper.Map<Project>(projectDto);
                
                _dbContext.Projects.Add(project);
                _dbContext.SaveChanges();
                return projectDto;
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
        public ProjectDto UpdateProject(int id, ProjectDto updatedProjectDto)
        {
            try
            {
                var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);

                project = _mapper.Map<Project>(updatedProjectDto);

                _dbContext.SaveChanges();
                return updatedProjectDto;
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

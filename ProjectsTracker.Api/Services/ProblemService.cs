using AutoMapper;
using ProblemsTracker;
using ProjectsTracker;
using ProjectsTracker.Domain.Employees;
using ProjectsTracker.Domain.Problems;
using ProjectsTracker.Domain.Projects;

namespace ProblemsTracker.Api.Services
{
    public interface IProblemService
    {
        /// <summary>
        /// Получить все задачи
        /// </summary>
        /// <returns>Задачи</returns>
        IEnumerable<Problem> GetProblems(TaskStatus? taskStatus);

        /// <summary>
        /// Получить задачу по Id
        /// </summary>
        /// <param name="id">Id задачи</param>
        /// <returns>Задача</returns>
        Problem GetProblem(int id);

        /// <summary>
        /// Создать задачу
        /// </summary>
        /// <param name="problem">Задача</param>
        /// <returns>Задача</returns>
        Problem CreateProblem(Problem problem);

        /// <summary>
        /// Изменить задачу
        /// </summary>
        /// <param name="id">Id задачи</param>
        /// <param name="updatedProblem">Задача</param>
        /// <returns>Задача</returns>
        Problem UpdateProblem(int id, Problem updatedProblem);

        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="problem">Задача</param>
        void DeleteProblem(Problem problem);

        /// <summary>
        /// Добавить сотрудника на проект
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="projectId">Id проекта</param>
        void AddEmployeeOnProject(Employee employee, int projectId);

        /// <summary>
        /// Удалить сотрудника из проекта
        /// </summary>
        /// <param name="employeeId">Id сотрудника</param>
        /// <param name="projectId">Id проекта</param>
        void DeleteEmployeeOnProject(int employeeId, int projectId);

    }
    public class ProblemService : IProblemService
    {
        #region Fields
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ProblemService(DbContext dbContext,
                              IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Получить все задачи
        /// </summary>
        /// <returns>Задачи</returns>
        public IEnumerable<Problem> GetProblems(TaskStatus? taskStatus)
        {
            try
            {
                var problems = _dbContext.Problems.AsQueryable().ApplyStatusFilter(taskStatus).ToList();
                return problems;
            }
            catch
            {
                throw new Exception("Произошла ошибка при извлечении задач.");
            }
        }

        /// <summary>
        /// Получить задачу по Id
        /// </summary>
        /// <param name="id">Id задачи</param>
        /// <returns>Задача</returns>
        public Problem GetProblem(int id)
        {
            var problem = _dbContext.Problems.FirstOrDefault(p => p.Id == id);
            if (problem == null)
            {
                throw new Exception("Задача не найдена");
            }
            return problem;
        }

        /// <summary>
        /// Создать новую задачу
        /// </summary>
        /// <param name="problem">Задача</param>
        /// <returns>Задача</returns>
        public Problem CreateProblem(Problem problem)
        {
            _dbContext.Problems.Add(problem);
            _dbContext.SaveChanges();
            return problem;
        }

        /// <summary>
        /// Изменить задачу
        /// </summary>
        /// <param name="id">Id задачи</param>
        /// <param name="updatedProblem">Задача</param>
        /// <returns>Задача</returns>
        public Problem UpdateProblem(int id, Problem updatedProblem)
        {
            try
            {
                var existingProblem = GetProblem(id);

                _mapper.Map(updatedProblem, existingProblem);
                _dbContext.SaveChanges();
                return existingProblem;
            }
            catch
            {
                throw new Exception("Произошла ошибка при изменении задачи.");
            }
        }

        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="problem">Задача</param>
        public void DeleteProblem(Problem problem)
        {
            _dbContext.Problems.Remove(problem);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Добавить сотрудника на проект
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="projectId">Id проекта</param>
        public void AddEmployeeOnProject(Employee employee, int projectId)
        {
            var project = _dbContext.Projects.FirstOrDefault(f => f.Id == projectId);
            project.Employees.Add(employee);
        }

        /// <summary>
        /// Удалить сотрудника из проекта
        /// </summary>
        /// <param name="employeeId">Id сотрудника</param>
        /// <param name="projectId">Id проекта</param>
        public void DeleteEmployeeOnProject(int employeeId, int projectId)
        {
            var project = _dbContext.Projects.FirstOrDefault(f => f.Id == projectId);
            project.Employees.Remove(new Employee { Id = employeeId });
        }


        #endregion
    }

    public static class ProblemFilterSerivce
    {
        public static IQueryable<Problem> ApplyStatusFilter(this IQueryable<Problem> problems, TaskStatus? taskStatus)
        {
            if (taskStatus == null)
            {
                return problems;
            }
            return problems.Where(w => w.Status == taskStatus);
        }
    }
}

using AutoMapper;
using ProjectsTracker.Domain.Models;

namespace ProjectsTracker.Application.Services
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
        private readonly IMapper _mapper;

        public ProblemService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddEmployeeOnProject(Employee employee, int projectId)
        {
            throw new NotImplementedException();
        }

        public Problem CreateProblem(Problem problem)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployeeOnProject(int employeeId, int projectId)
        {
            throw new NotImplementedException();
        }

        public void DeleteProblem(Problem problem)
        {
            throw new NotImplementedException();
        }

        public Problem GetProblem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Problem> GetProblems(TaskStatus? taskStatus)
        {
            throw new NotImplementedException();
        }

        public Problem UpdateProblem(int id, Problem updatedProblem)
        {
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using ProjectsTracker;
using ProjectsTracker.Domain.Problems;

namespace ProblemsTracker.Api.Services
{
    public interface IProblemService
    {
        IEnumerable<ProblemDto> GetProblems();
        ProblemDto GetProblem(int id);
        ProblemDto CreateProblem(ProblemDto problem);
        ProblemDto UpdateProblem(int id, ProblemDto updateProblemDto);
        int DeleteProblem(int id);

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
        /// Извлекает все задачи
        /// </summary>
        /// <returns>Все задачи</returns>
        public IEnumerable<ProblemDto> GetProblems()
        {
            try
            {
                var problems = _dbContext.Problems.ToList();
                var problemsDto = _mapper.Map<IEnumerable<ProblemDto>>(problems);
                return problemsDto;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, запись в лог или возврат специального значения
                Console.WriteLine("Произошла ошибка при извелечении задач: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Извлекает задачу по Id
        /// </summary>
        /// <param name="id">Id задачи</param>
        /// <returns>Найденная задача</returns>
        public ProblemDto GetProblem(int id)
        {
            try
            {
                var problem = _dbContext.Problems.FirstOrDefault(p => p.Id == id);
                var problemsDto = _mapper.Map<ProblemDto>(problem);
                return problemsDto;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, запись в лог или возврат специального значения
                Console.WriteLine("Произошла ошибка при извелечении задачи: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Создаёт новую задачу
        /// </summary>
        /// <param name="problem">Создаваемая задача</param>
        /// <returns>Созданная задача</returns>
        public ProblemDto CreateProblem(ProblemDto problemDto)
        {
            try
            {
                var problem = _mapper.Map<Problem>(problemDto);

                _dbContext.Problems.Add(problem);
                _dbContext.SaveChanges();
                return problemDto;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, запись в лог или возврат специального значения
                Console.WriteLine("Произошла ошибка при создании задачи: " + ex.Message);
                return null;
            }

        }
        /// <summary>
        /// Изменяет задачу 
        /// </summary>
        /// <param name="id">Id задачи</param>
        /// <param name="updatedProblem">Данные для обновления</param>
        /// <returns></returns>
        public ProblemDto UpdateProblem(int id, ProblemDto updatedProblemDto)
        {
            try
            {
                var problem = _dbContext.Problems.FirstOrDefault(p => p.Id == id);

                problem = _mapper.Map<Problem>(updatedProblemDto);

                _dbContext.SaveChanges();
                return updatedProblemDto;
            }
            catch (Exception ex)
            {
                // Обработка ошибок, например, запись в лог или возврат специального значения
                Console.WriteLine("Произошла ошибка при изменении задачи: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Удаляет задачу по Id
        /// </summary>
        /// <param name="id">Id задачи</param>
        /// <returns>Статус код</returns>
        public int DeleteProblem(int id)
        {
            var problem = _dbContext.Problems.FirstOrDefault(p => p.Id == id);
            if (problem == null)
                return 1;

            _dbContext.Problems.Remove(problem);
            _dbContext.SaveChanges();
            return 0;
        }
        #endregion
    }
}

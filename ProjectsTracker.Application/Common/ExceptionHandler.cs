using Microsoft.Extensions.Logging;

namespace ProjectsTracker.Application.Common
{
    public static class ExceptionHandler
    {
        public static T Handle<T>(Func<T> func, ILogger logger)
        {
            try
            {
                return func();
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, "Database error occurred.");
                throw new Exception("Ошибка при работе с базой данных", ex);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error occurred.");
                throw new Exception("Произошла ошибка при выполнении операции", ex);
            }
        }

        public static async Task<T> HandleAsync<T>(Func<Task<T>> func, ILogger logger)
        {
            try
            {
                return await func();
            }

            catch (SqlException ex)
            {
                logger.LogError(ex, "Database error occurred.");
                throw new Exception("Ошибка при работе с базой данных", ex);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error occurred.");
                throw new Exception("Произошла ошибка при выполнении операции", ex);
            }
        }
    }

}

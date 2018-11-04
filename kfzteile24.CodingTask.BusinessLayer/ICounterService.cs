using System.Threading.Tasks;

namespace kfzteile24.CodingTask.BusinessLayer
{
    /// <summary>
    /// Defines methods to retrieve and increment the counter value.
    /// </summary>
    public interface ICounterService
    {
        /// <summary>
        /// Gets the current counter value.
        /// </summary>
        /// <returns>The value.</returns>
        Task<int> RetrieveAsync();

        /// <summary>
        /// Internally increents the value of the counter.
        /// </summary>
        Task IncrementAsync();
    }
}

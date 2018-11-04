using System.Threading.Tasks;

namespace kfzteile24.CodingTask.DataLayer
{
    /// <summary>
    /// Defines methods to fetch and store values into a storage.
    /// </summary>
    public interface ICounterRepository
    {
        /// <summary>
        /// Gets the value from the storage.
        /// </summary>
        /// <returns>The value.</returns>
        Task<int> GetAsync();

        /// <summary>
        /// Puts the value into the storage.
        /// </summary>
        /// <param name="value">The value.</param>
        Task SetAsync(int value);
    }
}

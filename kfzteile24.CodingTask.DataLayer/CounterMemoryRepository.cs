using System.Threading.Tasks;

namespace kfzteile24.CodingTask.DataLayer
{
    /// <summary>
    /// Contains methods to work with the counter value which is stored in memory.
    /// </summary>
    public class CounterMemoryRepository : ICounterRepository
    {
        private int _value;

        /// <inheritdoc />
        public async Task<int> GetAsync()
        {
            return await Task.Run(() => _value);
        }

        /// <inheritdoc />
        public async Task SetAsync(int value)
        {
            await Task.Run(() => _value = value );
        }
    }
}

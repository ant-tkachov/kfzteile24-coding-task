using System;
using System.Threading.Tasks;

namespace kfzteile24.CodingTask.DataLayer
{
    /// <summary>
    /// Contains methods to work with the counter value which is stored in a database.
    /// </summary>
    public class CounterDbRepository : ICounterRepository
    {
        /// <inheritdoc />
        public Task<int> GetAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task SetAsync(int value)
        {
            throw new NotImplementedException();
        }
    }
}

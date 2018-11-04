using System.Threading.Tasks;
using kfzteile24.CodingTask.DataLayer;

namespace kfzteile24.CodingTask.BusinessLayer
{
    /// <summary>
    /// Implements functionality to retrieve and increment the counter value.
    /// </summary>
    public class CounterService : ICounterService
    {
        private readonly ICounterRepository _repository;

        /// <summary>
        /// Initializes a new instance of <see cref="ICounterService"/>.
        /// </summary>
        /// <param name="repository"><see cref="ICounterRepository"/>.</param>
        public CounterService(ICounterRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public async Task<int> RetrieveAsync()
        {
            int result = await _repository.GetAsync();

            return result;
        }

        /// <inheritdoc />
        public async Task IncrementAsync()
        {
            int value = await _repository.GetAsync();
            value++;
            await _repository.SetAsync(value);
        }
    }
}

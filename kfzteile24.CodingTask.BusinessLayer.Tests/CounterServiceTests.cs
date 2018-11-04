using System.Threading.Tasks;
using kfzteile24.CodingTask.DataLayer;
using NSubstitute;
using Xunit;

namespace kfzteile24.CodingTask.BusinessLayer.Tests
{
    public class CounterServiceTests
    {
        private readonly ICounterRepository _repository;

        public CounterServiceTests()
        {
            _repository = Substitute.For<ICounterRepository>();
        }

        [Fact]
        public async Task RetrieveAsyncGetsValue()
        {
            //arrange
            _repository.GetAsync().Returns(10);

            //act
            ICounterService service = new CounterService(_repository);
            int expected =  await service.RetrieveAsync();

            //assert
            Assert.Equal(10, expected);
        }

        [Fact]
        public async Task IncrementAsyncIncreasesValue()
        {
            //arrange
            _repository.GetAsync().Returns(10);

            //act
            ICounterService service = new CounterService(_repository);
            await service.IncrementAsync();

            //assert
            await _repository.Received(1).SetAsync(11);
        }
    }
}

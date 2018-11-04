using System.Net;
using System.Threading.Tasks;
using kfzteile24.CodingTask.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace kfzteile24.CodingTask.Web.Controllers
{
    /// <summary>
    /// Contains counter API methods.
    /// </summary>
    [Route("api/counter")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly ICounterService _counterService;

        /// <summary>
        /// Initializes a new instance of <see cref="CounterController"/>.
        /// </summary>
        /// <param name="counterService"><see cref="ICounterService"/>.</param>
        public CounterController(ICounterService counterService)
        {
            _counterService = counterService;
        }

        /// <summary>
        /// Retrieves the current counter value.
        /// </summary>
        /// <returns>The current counter value.</returns>
        [HttpGet("current")]
        [SwaggerTag("Counter")]
        [SwaggerOperation("Retrieve")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(int), Description = "The current counter value.")]
        public async Task<IActionResult> RetrieveAsync()
        {
            int result = await _counterService.RetrieveAsync();

            return Ok(result);
        }

        /// <summary>
        /// Increases the counter value.
        /// </summary>
        /// <returns><see cref="IActionResult"/>.</returns>
        [HttpPost("increment")]
        [SwaggerTag("Counter")]
        [SwaggerOperation("Increment")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IActionResult), Description = "Increases the counter value.")]
        public async Task<IActionResult> IncrementAsync()
        {
            await _counterService.IncrementAsync();

            return Ok();
        }
    }
}
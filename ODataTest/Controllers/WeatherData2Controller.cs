using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataTest.Controllers
{
    [ApiController]
    [Route("/odata/{controller}")]
    public class WeatherData2Controller : ControllerBase
    {
        private static IEnumerable<WeatherForecast> _items;
        private readonly ILogger<WeatherDataController> _logger;

        public WeatherData2Controller(ILogger<WeatherDataController> logger)
        {
            _logger = logger;
            _items = WeatherForecast.GenerateDemo();
        }

        [HttpGet]
        [EnableQuery]
        public Task<IQueryable<WeatherForecast>> Get()
        {
            return Task.Run(() =>
            {
                return _items.AsQueryable();
            });
        }
    }
}

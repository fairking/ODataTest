using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ODataTest.Controllers
{
    [ApiController]
    [Route("/odata/[controller]")]
    public class WeatherDataController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherDataController> _logger;

        public WeatherDataController(ILogger<WeatherDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [EnableQuery]
        public Task<IQueryable<WeatherForecast>> Get()
        {
            var rng = new Random();
            return Task.Run(() =>
            {
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Key = Guid.NewGuid().ToString("N"),
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .AsQueryable();
            });
        }

    }
}

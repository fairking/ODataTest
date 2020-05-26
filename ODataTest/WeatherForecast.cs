using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ODataTest
{
    public class WeatherForecast
    {
        [Key]
        public Guid Key { get; set; }

        public DateTime UtcDateTime { get; set; }

        public DateTime DateTime { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public decimal Pressure { get; set; }

        public string Summary { get; set; }

        public CloudsEnum Clouds { get; set; }

        public static IEnumerable<WeatherForecast> GenerateDemo(int count = 25)
        {
            var _summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

            var rng = new Random();
            var now = DateTime.Now;
            var today = new DateTime(now.Year, now.Month, now.Day);
            return Enumerable.Range(1, count).Select(index => new WeatherForecast
            {
                Key = Guid.NewGuid(),
                UtcDateTime = now.ToUniversalTime().AddDays(index),
                DateTime = now.AddDays(index),
                Date = today.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Pressure = 950 + (100 * (decimal)rng.NextDouble()),
                Clouds = (CloudsEnum)rng.Next(0, 2),
                Summary = _summaries[rng.Next(_summaries.Length)]
            });
        }
    }

    public enum CloudsEnum
    {
        Sunny,
        PartlyCloudy,
        Cloudy
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BinaryFog.SqlObjectComparer.DTO;

namespace BinaryFog.SqlObjectComparer.Controllers
{
    [Route("api/[controller]")]
    public class EnvironmentController : Controller
    {
        private readonly IRepository repository;
        
        public EnvironmentController(IRepository repository)
        {
            this.repository = repository;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {

            DTO.Environment env = new DTO.Environment() { Name = "Development", ConnectionStringTemplate="SQL={0}" };
            repository.AddEnvironment(env);


            var rng = new Random();
            
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
                                
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}

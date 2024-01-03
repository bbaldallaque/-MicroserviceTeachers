using Microsoft.AspNetCore.Mvc;

namespace MicroserviceTeachers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly TeacherContext _Context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TeacherContext context)
        {
            _logger = logger;
            _Context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_Context.Database.EnsureCreated());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

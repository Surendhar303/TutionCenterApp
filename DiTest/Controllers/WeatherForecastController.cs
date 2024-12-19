using Microsoft.AspNetCore.Mvc;

namespace DiTest.Controllers
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
        private readonly IStudentService _studentService1;
        private readonly IStudentService _studentService2;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStudentService studentService1, IStudentService studentService2)
        {
            _logger = logger;
            _studentService1 = studentService1;
            _studentService2 = studentService2;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public void Get()
        {
            int i = _studentService1.Get();
            int j = _studentService2.Get();
        }
    }
}

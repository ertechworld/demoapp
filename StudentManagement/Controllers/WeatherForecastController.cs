using Microsoft.AspNetCore.Mvc;
using DTO;

namespace StudentManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool","Warmm", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("GetStudents")]
        public IActionResult GetStudents()
        {
            try
            {
                List<User> students = new List<User>();
                User student = new User()
                {
                    FullName = "Anil Kumar",
                    RollNumber = 100,
                    Fee = 10.50M
                };
                students.Add(student);

                student = new User()
                {
                    FullName = "Payal",
                    RollNumber = 101,
                    Fee = 100.50M
                };
                students.Add(student);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest("Input string is wrong, please validate your program");
            }
            finally
            {

            }
        }

        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent(User model)
        {
            try
            {

                return Ok("Student has been added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("unable to add student due to these reasons : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginModel model)
        {
            try
            {
                User user = new User()
                {
                    Email = model.Email,
                    Password = model.Password
                };
                return Ok("Student has been loggedin successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("unable to login student due to these reasons : " + ex.Message);
            }
        }
    }

}

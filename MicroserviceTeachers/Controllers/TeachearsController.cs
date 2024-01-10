using MicroserviceTeachers.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceTeachers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachearsController : ControllerBase
    {
        private readonly ILogger<TeachearsController> _logger;
        private readonly TeacherContext _dbcontext;
        private readonly ITeacher _teacher;

        public TeachearsController(ILogger<TeachearsController> logger, TeacherContext dbContext, ITeacher teacher)
        {
            _logger = logger;
            _dbcontext = dbContext;
            _teacher = teacher;
        }

        [HttpGet]
        [Route("CreateDatabase")]
        public IActionResult CreateDatabase()
        {
            try
            {
                _logger.LogInformation("Creando base de datos");
                return Ok(_dbcontext.Database.EnsureCreated());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creando base de datos {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTeachear")]
        public IActionResult GetEstudent()
        {

            return Ok(_teacher.GetTeachers());
        }

        [HttpGet]
        [Route("GetTeachearByIdentification/{identification}")]
        public IActionResult GetTeachearByIdentification(int identification)
        {
            return Ok(_teacher.GetTeacherByIdentification(identification));
        }

        [HttpPost]
        [Route("CreateTeachear")]
        public IActionResult CreateUser(Models.Teacher teacher)
        {
            return Ok(_teacher.CreateTeacher(teacher));
        }

        [HttpDelete]
        [Route("DeleteTeacher/{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                if (_teacher.DeleteTeacher(id))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("No se pudo eliminar correctamente el usuario");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error eliminando usuarios {ex.Message.ToString()}");
            }
        }
    }
}
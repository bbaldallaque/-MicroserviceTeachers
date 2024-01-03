using MicroserviceTeachers.Services.Interfaces;

namespace MicroserviceTeachers.Services
{
    public class Teacher : ITeacher
    {
        private readonly ILogger<Teacher> _logger;
        private readonly ITeacherContext _dbContext;

        public Teacher(ILogger<Teacher> logger, ITeacherContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public bool CreateTeacher(Models.Teacher teacher)
        {
            bool result = false;
            try
            {
                teacher.Id = Guid.NewGuid();
                _dbContext.Teachears.Add(teacher);
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error creando data de user {ex.Message.ToString()}");
            }
            return result;
        }

        public bool DeleteTeacher(Guid id)
        {
            bool result = false;
            try
            {
                Models.Teacher teacher = FindTeacher(id);
                if (teacher != null)
                {
                    _dbContext.Teachears.Remove(teacher);
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error obteniendo data de user {ex.Message.ToString()}");
            }
            return result;
        }

        public Models.Teacher FindTeacher(Guid id)
        {
            return _dbContext.Teachears .Find(id);
        }

        public Models.Teacher GetTeacherByIdentification(int identification)
        {
            Models.Teacher result = null;
            try
            {
                result = _dbContext.Teachears.Where(x => x.Identification == identification)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error obteniendo data de Docente {ex.Message.ToString()}");
            }
            return result;
        }

        public List<Models.Teacher> GetTeachers()
        {
            List<Models.Teacher> result = null;
            try
            {
                result = _dbContext.Teachears.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error obteniendo data de estudiante {ex.Message}");
            }
            return result;
        }
    }
}

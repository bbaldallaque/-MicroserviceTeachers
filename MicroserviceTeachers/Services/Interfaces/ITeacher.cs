namespace MicroserviceTeachers.Services.Interfaces
{
    public interface ITeacher
    {
        public List<Models.Teacher> GetTeachers();

        public Models.Teacher GetTeacherByIdentification(int identification);

        public bool CreateTeacher(Models.Teacher Teacher);

        public bool DeleteTeacher(Guid id);

        public Models.Teacher FindTeacher(Guid id);
    }
}

using MicroserviceTeachers.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceTeachers
{
    public interface ITeacherContext
    {
        DbSet<Teacher> Teachears { get; set; }

        void SaveChanges();
    }
}

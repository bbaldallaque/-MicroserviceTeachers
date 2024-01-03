using MicroserviceTeachers.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceTeachers
{
    public class TeacherContext : DbContext, ITeacherContext
    {
        public TeacherContext(DbContextOptions<TeacherContext> options) : base(options) { }
        
        public DbSet<Teacher> Teachears { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Teacher>(teacher =>
            {
                teacher.ToTable("Teacher");
                teacher.HasKey(x => x.Id);
                teacher.Property(x => x.Name).IsRequired().HasMaxLength(50);
                teacher.Property(x => x.Email).IsRequired().HasMaxLength(100);
                teacher.Property(x => x.TypeIdentificationEnums).IsRequired();
                teacher.Property(x => x.Identification).IsRequired();
                teacher.Property(x => x.Specialty).IsRequired();
            });       
        }

        void ITeacherContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}

using MicroserviceTeachers.Enums;
using System.ComponentModel.DataAnnotations;

namespace MicroserviceTeachers.Models
{
    public class Teacher
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public TypeIdentificationEnums TypeIdentificationEnums { get; set; }

        [Required]
        public int Identification { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        [Required]
        public string Specialty { get; set; }
    }
}

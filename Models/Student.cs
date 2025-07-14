using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public required string Fname { get; set; }
        public required string Lname { get; set; }
        public int age { get; set; }
        public string? address { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }


    }
}

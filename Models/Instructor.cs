using System.ComponentModel.DataAnnotations.Schema;

namespace ITIManagementSystem.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal Bonus { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; } // Working Relation ship
        [ForeignKey("DepartmentId")]
         public Department WorkingDepartment { get; set; }
        
        public ICollection<InstructorCourse> InstructorsCourses { get; set; }
        public Department? ManagedDepartment { get; set; } // Null cause not all the employees are managers.




    }
}

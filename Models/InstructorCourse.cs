using System.ComponentModel.DataAnnotations;

namespace ITIManagementSystem.Models
{
    public class InstructorCourse
    {
        public Instructor instructor {  get; set; }
        public int instructorId { get; set; }

        public Course course { get; set; }
        public int courseId { get; set; }
        [Range(0, 10, ErrorMessage = "Evaluation must be between 0 and 10.")]
        public double Evaluation { get; set; }
    }
}

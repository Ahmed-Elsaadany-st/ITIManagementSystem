using System.ComponentModel.DataAnnotations.Schema;

namespace ITIManagementSystem.Models
{
    public class Course
    {
        public int id { get; set; }
        public  string name { get; set; }
        public string description { get; set; }
        public  double Duration { get; set; }
       
        public int TopicId { get; set; }
        [ForeignKey("TopicId")]
            
        public Topic Topic { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<InstructorCourse> InstructorCourses { get; set; }

    }
}

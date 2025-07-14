namespace ITIManagementSystem.Models
{
    public class StudentCourse
    {
        public Student student { get; set; }
        public int studentId { get; set; }

        public Course course { get; set; }
        public int courseId { get; set; }

        public double Grade { get; set; } // One Of The Advantages of Exciplit Join table is to add Additiona Columns like this

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace ITIManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ManagerId { get; set; }        //For the management Relationship (The Department is managed by one instructor)
        [ForeignKey("ManagerId")]
        public Instructor Manager { get; set; }
        public DateOnly ManagerHiringDate { get; set; }
        public List<Instructor> Instructors { get; set; } // => For the working relation ship(One Department Contaions many Instructors)
        public  List<Student> Students { get; set; }

    }
}

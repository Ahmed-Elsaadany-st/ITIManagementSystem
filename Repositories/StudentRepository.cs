using ITIManagementSystem.Models;

namespace ITIManagementSystem.Repositories
{
    public class StudentRepository
    {
        private readonly ITIContext itiContext;

        public StudentRepository(ITIContext itiContext)
        {
            this.itiContext = itiContext;
        }
        public List<Student> GetAll()=> itiContext.Students.ToList();
        public Student GetByid(int id) => itiContext.Students.FirstOrDefault(s => s.id == id);
        public void Add (Student student)=>itiContext.Students.Add(student);
        public void update (Student Old,Student New)=>itiContext.Entry(Old).CurrentValues.SetValues(New);
        public void Delete(int id)=>itiContext.Students.Remove(GetByid(id));

        
           
        
    }
}

using Microsoft.EntityFrameworkCore;

namespace ITIManagementSystem.Models
{
    public class ITIContext : DbContext
    {
        //This the Constructor that deals with DI
        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-8V6V1A0;Initial Catalog=ITIDatabase;Integrated Security=True;Encrypt=False");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Full Configuration for the table(StudentCourse) that links between Student and Course
            modelBuilder.Entity<StudentCourse>()
        .HasKey(K => new { K.studentId, K.courseId }); // Setting The Composite Primary Key

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.student)
                .WithMany(s => s.StudentCourses) // Setting the One To Many Relation between Student(1) and StudentCourse(m)
                .HasForeignKey(sc => sc.studentId); //Determine the Foregin Key

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.course)
                .WithMany(c => c.StudentCourses) // Setting the One To Many Relation between Course(1) and StudentCourse(m)
                .HasForeignKey(sc => sc.courseId); //Determine the Foregin Key

            #endregion

            #region Full Configuration for the table(InstructorCourse) that Links between Instructor and Course
            modelBuilder.Entity<InstructorCourse>()
       .HasKey(K => new { K.courseId, K.instructorId }); //Setting The Composite Primary Key

            modelBuilder.Entity<InstructorCourse>()
                .HasOne(ic => ic.instructor)
                .WithMany(i => i.InstructorsCourses) //Setting the one to many relation ship between instructor(1) and instrucotrCourse(m)
                .HasForeignKey(ic => ic.instructorId); // Determine the Fk for that relation

            modelBuilder.Entity<InstructorCourse>()
                .HasOne(ic => ic.course)
                .WithMany(i => i.InstructorCourses) //Setting the one to many relation ship between Course(1) and instrucotrCourse(m)
                .HasForeignKey(ic => ic.courseId); // Determine the Fk for that relation

            #endregion

            #region Confinguration for the relaitons between instructor and deparment
            // We need to write the configuration manully cause there are two relations (Working and Management)
            // and they make the EFC confused

            #region Working Relation
            modelBuilder.Entity<Instructor>()
                .HasOne(i=>i.WorkingDepartment)
                .WithMany(d=>d.Instructors)
                .HasForeignKey(i=>i.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Management Relation
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithOne(M => M.ManagedDepartment)
                .HasForeignKey<Department>(d => d.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #endregion



        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> studentCourses  { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorCourse> InstructorCourse {  get; set; }

    }
}

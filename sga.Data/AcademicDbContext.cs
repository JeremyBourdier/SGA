using sga.Data;
using Microsoft.EntityFrameworkCore;

namespace sga.Data
{
    public class AcademicDbContext : DbContext
    {
        public AcademicDbContext(DbContextOptions<AcademicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AcademicRecord> AcademicRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar llaves compuestas, etc.
            modelBuilder.Entity<CourseTeacher>()
                .HasKey(ct => ct.Id);

            // etc...
        }
    }
}

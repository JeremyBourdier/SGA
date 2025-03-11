using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sga.Data.Entities.AcademicService
{
    [Table("Teacher")]
    public class Teacher
    {
        public int Id { get; set; }

        // Soft reference a AuthDB.User
        public int UserId { get; set; }

        public string Department { get; set; }
        public string Specialty { get; set; }
        public DateTime? HireDate { get; set; }
    }
}

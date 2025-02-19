using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sga.Data.Entities
{
    [Table("Teacher")]
    public class Teacher
    {
        public int Id { get; set; }
        public int UserId { get; set; }      // Soft reference to AuthDB.User
        public string Department { get; set; }
        public string Specialty { get; set; }
        public DateTime? HireDate { get; set; }
    }
}

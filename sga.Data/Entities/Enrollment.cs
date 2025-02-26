using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sga.Data.Entities
{
    [Table("Enrollment")]
    public class Enrollment
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Term { get; set; }   // e.g. '2020-3', '2021-1'
        public string Status { get; set; } // e.g. 'Enrolled', 'Approved', 'Failed'
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}

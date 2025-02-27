using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sga.Data.Entities
{
    [Table("Attendance")]
    public class Attendance
    {
        public int Id { get; set; }
        public string Status { get; set; } // e.g. 'Present', 'Absent', 'Justified'
        public DateTime AttendanceDate { get; set; }
        public int EnrollmentId { get; set; }
    }
}

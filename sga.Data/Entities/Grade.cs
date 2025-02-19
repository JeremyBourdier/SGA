using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sga.Data.Entities
{
    [Table("Grade")]
    public class Grade
    {
        public int Id { get; set; }
        public double? FinalScore { get; set; }
        public string EvaluationType { get; set; } // e.g. 'Partial', 'Homework', 'Final'
        public int EnrollmentId { get; set; }
    }
}

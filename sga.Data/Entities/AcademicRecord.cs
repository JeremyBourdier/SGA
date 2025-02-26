using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sga.Data.Entities
{
    [Table("AcademicRecord")]
    public class AcademicRecord
    {
        public int Id { get; set; }
        public double? Average { get; set; }
        public string Term { get; set; }   // e.g. '2020-3'
        public int StudentId { get; set; }
    }
}

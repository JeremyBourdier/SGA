using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sga.Data.Entities
{
    [Table("Degree")]
    public class Degree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Duration { get; set; }   // e.g. number of semesters
        public string Modality { get; set; } // e.g. 'onsite', 'online'
    }
}

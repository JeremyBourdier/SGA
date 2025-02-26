using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sga.Data.Entities
{
    [Table("Student")]
    public class Student
    {
        public int Id { get; set; }
        public int UserId { get; set; }         // Soft reference to AuthDB.User
        public int DegreeId { get; set; }       // FK to Degree
        public string RegistrationNumber { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}

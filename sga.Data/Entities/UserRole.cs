using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sga.Data.Entities
{
    // Many-to-many relationship between User and Role
    [Table("UserRole")]
    public class UserRole
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
    }
}

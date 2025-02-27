using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sga.Data.Entities
{
    // Many-to-many relationship between Role and Permission
    [Table("RolePermission")]
    public class RolePermission
    {
        public int RoleID { get; set; }
        public int PermissionID { get; set; }
    }
}

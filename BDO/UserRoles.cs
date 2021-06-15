using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCrud.BDO
{
    public class UserRoles
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public int RoleId { get; set; }

    }
}

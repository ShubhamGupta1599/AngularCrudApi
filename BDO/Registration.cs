using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCrud.BDO
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string password { get; set; }
        public Int64 PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string State { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }
        public int PinCode { get; set; }
        public bool Active { get; set; }

    }
}

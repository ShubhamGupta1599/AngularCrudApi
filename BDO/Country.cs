using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCrud.BDO
{
    public class Country
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string CountryName { get; set; }
        public ICollection<State> States { get; set; }
    }
}

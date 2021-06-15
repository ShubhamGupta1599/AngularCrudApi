using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCrud.BDO
{
    public class City
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string CityName { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }
    }
}

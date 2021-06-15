using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCrud.BDO
{
    public class State
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string StateName { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}

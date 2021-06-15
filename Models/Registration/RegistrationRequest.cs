using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCrud.Models.Registration
{
    public class RegistrationReq
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Int64 PhoneNumber { get; set; } = 0;
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int PinCode { get; set; } = 0;
        public bool Active { get; set; } = true;
    }
}

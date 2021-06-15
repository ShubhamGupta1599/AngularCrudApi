using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularCrud.Models.Registration;

namespace AngularCrud.Interfaces
{
    public interface IRegistration
    {
        void PostRegistration(RegistrationReq model);
        IEnumerable<RegistrationRes> GetAllRegistration();
        RegistrationRes GetByIdRegistration(int id);
        bool DeleteByIdRegistration(int id);
    }
}

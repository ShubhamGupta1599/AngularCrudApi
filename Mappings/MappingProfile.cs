using AngularCrud.BDO;
using AngularCrud.Models.Registration;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCrud.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationReq, Registration>(); 
            CreateMap<Registration, RegistrationRes>(); 
        }
    }
}

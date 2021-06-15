using AngularCrud.BDO;
using AngularCrud.Interfaces;
using AngularCrud.Models.Registration;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCrud.DAL
{
    public class RegistrationServices : IRegistration
    {
        private readonly DataContext _dbcontext;
        private readonly IMapper _mapper;
        public RegistrationServices(DataContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public bool DeleteByIdRegistration(int id)
        {
            var data = _dbcontext.Registration.Find(id);
            data.Active = false;
            _dbcontext.Entry(data).State = EntityState.Modified;
            try
            {
                _dbcontext.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public IEnumerable<RegistrationRes> GetAllRegistration()
        {
            var getdata = _dbcontext.Registration.Where(x=>x.Active);
            var returndata = _mapper.Map<IList<RegistrationRes>>(getdata);
            return returndata;
        }

        public RegistrationRes GetByIdRegistration(int id)
        {
            var getdata = _dbcontext.Registration.Where(x=>x.Id==id && x.Active).FirstOrDefault();
            var returndata = _mapper.Map<RegistrationRes>(getdata);
            return returndata;
        }

        public void PostRegistration(RegistrationReq model)
        {
            var data = _mapper.Map<Registration>(model);            
            if (data.Id != 0)
            {
                var result = new Registration()
                {
                    Id = data.Id
                };
                _dbcontext.Entry(data).State = EntityState.Modified;
                _dbcontext.SaveChanges();
            }
            else
            {
                _dbcontext.Add(data);
                _dbcontext.SaveChanges();
            }
        }
    }
}

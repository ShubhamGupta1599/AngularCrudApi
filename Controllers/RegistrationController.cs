using AngularCrud.BDO;
using AngularCrud.Interfaces;
using AngularCrud.Models.Registration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCrud.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistration _Iregistration;
        private readonly DataContext _dbcontext;
        public RegistrationController(IRegistration Iregistration, DataContext dbcontext)
        {
            _Iregistration = Iregistration;
            _dbcontext = dbcontext;
        }

        [HttpPost("upsert")]
        public ActionResult<RegistrationReq> CreateUser(RegistrationReq model)
        {
            bool userexist = _dbcontext.Registration.Any(x => x.email == model.email);
            if (!userexist)
            {
                try
                {
                    _Iregistration.PostRegistration(model);
                    return Ok(new { Message = "" });
                }
                catch (Exception e)
                {
                    return Ok(new { Message = "Server not responded." });
                }
            }
            return Ok(new { Message = "E-mail Id Already Existed." });
        }
        [HttpGet("getallregistration")]
        public ActionResult<IEnumerable<RegistrationRes>> GetAllRegistration()
        {
                var result = _Iregistration.GetAllRegistration().ToList();
                if (result.Count != 0)
                {
                    return result;
                }
                else
                {
                    return NotFound();
                }
        }
        [HttpGet("getbyidregistration/{id}")]
        public ActionResult<RegistrationRes> GetByIdRegistration(int id)
        {
            var idexist = _dbcontext.Registration.Any(x => x.Id == id);
            if (idexist)
            {
                try
                {
                    var result = _Iregistration.GetByIdRegistration(id);
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return Ok(new { Message = "User id does not exist" });
        }
        [HttpDelete("deleteuser/{id}")]
        public ActionResult DeleteUser(int id)
        {
            var idexist = _dbcontext.Registration.Any(x => x.Id == id);
            if (idexist)
            {
                try
                {
                    var result = _Iregistration.DeleteByIdRegistration(id);
                    if (result)
                    {
                        return Ok(new { Message = "" });
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return NotFound();
        }

    }
}

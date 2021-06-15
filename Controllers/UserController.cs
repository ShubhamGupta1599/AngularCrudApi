using AngularCrud.BDO;
using AngularCrud.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using AngularCrud.Models;
using Microsoft.Extensions.Options;

namespace AngularCrud.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dbcontext;
        private readonly ApplicationSettings _appSettings;
        public UserController(DataContext dbcontext, IOptions<ApplicationSettings> appSettings)
        {
            _dbcontext = dbcontext;
            _appSettings = appSettings.Value;
        }

        [HttpPost("login")]
        public ActionResult Login(Login model)
        {
            var user = _dbcontext.Registration.Where(x=>x.email == model.UserName && x.Active).FirstOrDefault();
            bool exist = _dbcontext.Registration.Any(x => x.email == model.UserName && x.password == model.Password);
            if(user!=null && exist)
            {

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("UserID", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest();
            }
        }

    }
}

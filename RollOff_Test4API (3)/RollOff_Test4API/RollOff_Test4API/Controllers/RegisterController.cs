using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RollOff_Test4API.Data;
using RollOff_Test4API.Models.Domain;
using RollOff_Test4API.Services;
using System;

using System.Linq;
using System.Threading.Tasks;

namespace RollOff_Test4API.Controllers
{
    #region UserRegistrationandLogin

   
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private registerservice _RegService;
        private readonly IConfiguration _config;
        public readonly RollOff4DbContext _context;
        public RegisterController(registerservice service, IConfiguration config, RollOff4DbContext context)//dependency injection
        {
            _config = config;
            _RegService = service;
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> Create(Register reg)//USer registration
        {
            var u = await _RegService.CreateUser(reg);
            try
            {
                if (reg == null)
                {
                    return Ok("Already Exist");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("User not found");
            }
            return Ok("User created");

        }
       //[AllowAnonymous]
        [HttpPost("LoginUser")]
        public  IActionResult Login(Login log)//User Login
        {
            var UserAvailable = _context.Register.Where(u => u.Email == log.Email && u.PWD == log.PWD).FirstOrDefault();
            {
                try
                {
                    if (UserAvailable == null)
                    {
                        return Ok("Failure");
                    }
                }
                  
                
                catch(Exception e)
                {
                    Console.WriteLine("User not found");
                }
                return Ok(new JWTService(_config).GenerateToken(
                          UserAvailable.FirstName,
                          UserAvailable.LastName,
                          UserAvailable.Email,
                          UserAvailable.Role
                          ));
            }
        }
    }
    #endregion
}



using EBuy.DAL;
using EBuy.DAL.Models.EF_Models;
using EBuy.DAL.Models.Results;
using EBuy.Website.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBuy.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly Identity identity;
        public IdentityController()
        {
            identity = new Identity();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            try
            {
                UserResult userResult = identity.RegisterUser(user);

                if (!userResult.Succeeded)
                {
                    return BadRequest(new { result = "user registration failed!" });
                }

                return Ok(new { result = "user registration is succesfully done!" });
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                UserResult userResult = identity.Login(user);
                return Ok(userResult);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            try
            {
                List<RoleResult> roles = identity.GetAllRoles();
                return Ok(roles);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}

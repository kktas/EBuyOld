using EBuy.DAL;
using EBuy.DAL.Models.EF_Models;
using EBuy.DAL.Models.Results;
using EBuy.Website.ApiCalls;
using EBuy.Website.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EBuy.Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly IdentityCaller identityCaller;
        public AccountController()
        {
            identityCaller = new IdentityCaller();
        }
        [HttpGet]
        public async Task<IActionResult> LoginAsync()
        {
            await HttpContext.SignOutAsync();
            TempData["logout"] = true;
            return View(new Login());
        }

        //TO DO: CHECK CREDENTIALS FROM DB VIA API
        //CORRECT=> LOG IN AND GO TO HOMEPAGE
        //wRONG=> RETURN TO SAME PAGE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(Login login)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Email = login.Email,
                    Password = login.Password
                };

                UserResult userResult = identityCaller.ApiCall_Login(user);
                if (userResult.Succeeded)
                {
                    List<RoleResult> roles = identityCaller.ApiCall_GetAllRoles();

                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Sid, $"{userResult.User.Id}" ),
                    new Claim(ClaimTypes.Name, userResult.User.Email),
                    new Claim("FullName", userResult.User.FirstName + " " + userResult.User.LastName),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault(x=> userResult.User.RoleId == x.Id).RoleName),
                };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity)
                        );

                    return Redirect("/");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegisterAsync()
        {
            await HttpContext.SignOutAsync();
            IdentityCaller identityCaller = new IdentityCaller();
            List<RoleResult> roles = identityCaller.ApiCall_GetAllRoles();

            var register = new Register() { Roles = roles };
            return View(register);
        }

        //DONE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(Register register)
        {
            List<RoleResult> roles = identityCaller.ApiCall_GetAllRoles();

            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    RoleId = register.Role,
                    Email = register.Email,
                    Password = register.Password,
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                };
                //REGISTER AND LOGIN
                identityCaller.ApiCall_RegisterUser(user);

                return Redirect("/");
            }

            return View(new Register() { Roles = roles });
        }

        //DONE
        [HttpGet]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}

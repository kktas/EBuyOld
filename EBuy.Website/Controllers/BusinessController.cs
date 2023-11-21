using EBuy.Website.ApiCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EBuy.Website.Controllers
{
    [Authorize(Roles = ("Satıcı"))]
    public class BusinessController : Controller
    {
        private readonly MarketCaller marketCaller;
        public BusinessController()
        {
            marketCaller = new MarketCaller();
        }
        public IActionResult SalesReport()
        {
            var userIdentity = User.Identity as ClaimsIdentity;
            var userId_string= userIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            var userId = Convert.ToInt32(userId_string);

            var sales = marketCaller.GetSales(userId);
            return View(sales);
        }
    }
}

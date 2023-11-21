using EBuy.DAL.Models.EF_Models;
using EBuy.DAL.Models.Results;
using EBuy.Website.ApiCalls;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EBuy.Website.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MarketCaller marketCaller;

        public CustomerController()
        {
            marketCaller = new MarketCaller();
        }

        [HttpGet]
        public IActionResult MyCart()
        {
            var userIdentity = User.Identity as ClaimsIdentity;
            var userId_string = userIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            var userId = Convert.ToInt32(userId_string);

            List<CartItemResult> cartItems= marketCaller.GetCartItems(userId);
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult RemoveFromCart([FromBody]intData data)
        {
            marketCaller.RemoveCartItem(data.Id);
            string redirectUrl = Url.Action("MyCart");
            return Json(new { redirectUrl });
        }

        [HttpPost]
        public IActionResult BuyProducts([FromBody] intData data)
        {
            marketCaller.BuyProducts(data.Id);
            string redirectUrl = Url.Action("MyCart");
            return Json(new { redirectUrl });
        }

        public class intData
        {
            public int Id { get; set; }
        }

    }
}

using EBuy.DAL.Models.EF_Models;
using EBuy.DAL.Models.Results;
using EBuy.Website.ApiCalls;
using EBuy.Website.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EBuy.Website.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly MarketCaller marketCaller;
        public HomeController()
        {
            marketCaller = new MarketCaller();
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = marketCaller.GetAllProducts();
            return View(products);
        }


        public IActionResult ProductDetail(int id)
        {
            Product product = marketCaller.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] CartItem cartItem)
        {
            var userIdentity = User.Identity as ClaimsIdentity;
            var userId_string = userIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
            var userId = Convert.ToInt32(userId_string);

            //CartItem cartItem = new CartItem()
            //{
            //    CustomerId = userId,
            //    Amount = amount,
            //    TotalPrice = totalPrice,
            //    ProductId = productId
            //};

            cartItem.CustomerId = userId;
            marketCaller.AddCartItem(cartItem);

            return Redirect("/");
        }
    }
}

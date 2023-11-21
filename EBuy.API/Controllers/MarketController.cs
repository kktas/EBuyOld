using EBuy.DAL;
using EBuy.DAL.Models.EF_Models;
using EBuy.DAL.Models.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBuy.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MarketController : Controller
    {
        private readonly Market market;
        public MarketController()
        {
            market = new Market();
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            List<Product> products =market.GetAllProducts();
            return Ok(products);
        }

        [HttpGet]
        public IActionResult GetProduct(int productId)
        {
            Product product = market.GetProductById(productId);
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetBrandProducts(int userId)
        {
            List<Product> products = market.GetProductsByBrandId(userId);
            return Ok(products);
        }

        [HttpGet]
        public IActionResult GetCartItems(int userId)
        {
            List<CartItemResult> cartItems = market.GetCartItemsByCustomerId(userId);
            return Ok(cartItems);
        }

        [HttpGet]
        public IActionResult GetSales(int userId)
        {
            List<SaleResult> sales = market.GetSalesByBrandId(userId);
            return Ok(sales);
        }
        [HttpGet]
        public IActionResult BuyProducts(int userId)
        {
            market.BuyProducts(userId);
            return Ok();
        }
        [HttpGet]
        public IActionResult RemoveCartItem(int cartItemId)
        {
            market.RemoveCartItemFromCart(cartItemId);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddCartItem([FromBody]CartItem cartItem)
        {
            market.AddCartItem(cartItem);
            return Ok();
        }
    }
}

using EBuy.DAL.Models.EF_Models;
using EBuy.DAL.Models.Results;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBuy.Website.ApiCalls
{
    public class MarketCaller
    {
        private const string apiUrl = "https://localhost:44308/";
        public List<Product> GetAllProducts()
        {
            var client = new RestClient(apiUrl + "api/market/getallproducts");
            var request = new RestRequest();

            request.Method = Method.Get;
            var response = client.Execute(request);

            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(response.Content);

            return products;
        }

        public Product GetProduct(int productId)
        {
            var client = new RestClient(apiUrl + $"api/market/getproduct?productid={productId}");
            var request = new RestRequest();

            request.Method = Method.Get;
            var response = client.Execute(request);

            Product product = JsonConvert.DeserializeObject<Product>(response.Content);
            return product;
        }

        public List<Product> GetProducts(int userId)
        {
            var client = new RestClient(apiUrl + $"api/market/getbrandproducts?userid={userId}");
            var request = new RestRequest();

            request.Method = Method.Get;
            var response = client.Execute(request);

            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(response.Content);
            return products;
        }

        public List<CartItemResult> GetCartItems(int userId)
        {
            var client = new RestClient(apiUrl + $"api/market/getcartitems?userid={userId}");
            var request = new RestRequest();

            request.Method = Method.Get;
            var response = client.Execute(request);

            List<CartItemResult> cartItems = JsonConvert.DeserializeObject<List<CartItemResult>>(response.Content);
            return cartItems;
        }

        public List<SaleResult> GetSales(int userId)
        {
            var client = new RestClient(apiUrl + $"api/market/getsales?userid={userId}");
            var request = new RestRequest();

            request.Method = Method.Get;
            var response = client.Execute(request);

            List<SaleResult> sales = JsonConvert.DeserializeObject<List<SaleResult>>(response.Content);
            return sales;
        }

        public void BuyProducts(int userId)
        {
            var client = new RestClient(apiUrl + $"api/market/buyproducts?userid={userId}");
            var request = new RestRequest();

            request.Method = Method.Get;
            client.Execute(request);
        }

        public void RemoveCartItem(int cartItemId)
        {
            var client = new RestClient(apiUrl + $"api/market/removecartitem?cartitemid={cartItemId}");
            var request = new RestRequest();

            request.Method = Method.Get;
            client.Execute(request);
        }

        public void AddCartItem(CartItem cartItem)
        {
            var client = new RestClient(apiUrl + "api/market/addcartitem");
            var request = new RestRequest();

            request.Method = Method.Post;
            var cartItemJson = JsonConvert.SerializeObject(cartItem);

            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(cartItemJson);
            client.Execute(request);
        }
    }
}

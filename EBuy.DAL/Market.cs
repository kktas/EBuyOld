using EBuy.DAL.Models.EF_Models;
using EBuy.DAL.Models.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.DAL
{
    public class Market
    {
        private readonly Context db;

        public Market()
        {
            db = new Context();
        }
        public List<Product> GetAllProducts()
        {
            List<Product> products = db.Products.ToList();
            return products;
        }

        public Product GetProductById(int productId)
        {
            Product product = db.Products.FirstOrDefault(x=>x.Id==productId);
            return product;
        }
        public List<Product> GetProductsByBrandId(int userId)
        {
            List<Product> products = db.Products.Where(x => x.Brand.UserId == userId).ToList();
            return products;
        }

        public List<CartItemResult> GetCartItemsByCustomerId(int userId)
        {
           List<CartItemResult> cartItems = db.CartItems
                .Include(x=>x.Product)
                .Select(x=> new CartItemResult(){
                 Id= x.Id,
                 ProductId= x.ProductId,
                 Customer= x.Customer,
                 ProductName= x.Product.ProductName,
                 ProductDetail= x.Product.DetailText,
                 Amount = x.Amount,
                 TotalPrice=x.TotalPrice,
                 ImageName = x.Product.ImageName
                })
                .Where(x => x.Customer.UserId == userId).ToList();
            return cartItems;
        }

        public List<SaleResult> GetSalesByBrandId(int userId)
        {
            var sales = db.Sales
                .Include(x=>x.Product)
                .Include(x=>x.Customer).ThenInclude(x=>x.User)
                .Where(x => x.Product.Brand.UserId == userId);

            List<SaleResult> saleResults = new List<SaleResult>();
            
            foreach(var sale in sales)
            {
                var customerUser = sale.Customer.User;
                SaleResult saleResult = new SaleResult
                {
                    CustomerName = customerUser.FirstName+" "+customerUser.LastName,
                    ProductName = sale.Product.ProductName,
                    Amount = sale.Amount,
                    TotalPrice = sale.TotalPrice,
                    Date = sale.Date
                };
                saleResults.Add(saleResult);
            }
            return saleResults;
        }

        public void BuyProducts(int userId)
        {
            List<CartItem> cartItems = db.CartItems.Where(x=>x.Customer.UserId ==userId).ToList();
            foreach (var item in cartItems)
            {
                var product = GetProductById(item.ProductId);
                product.Stock -= item.Amount;
                db.Sales.Add(new Sale { ProductId = item.ProductId, Amount = item.Amount, CustomerId = item.CustomerId, TotalPrice = item.TotalPrice });
                db.CartItems.Remove(item);
            }
            db.SaveChanges();
        }

        public void RemoveCartItemFromCart(int cartItemId)
        {
            CartItem cartItem= db.CartItems.FirstOrDefault(x=>x.Id==cartItemId);
            db.CartItems.Remove(cartItem);
            db.SaveChanges();
        }

        public void AddCartItem(CartItem cartItem)
        {
            try
            {
                var customerId = db.Customers.SingleOrDefault(x => x.UserId == cartItem.CustomerId).Id;
                var cartItemInDb = db.CartItems.FirstOrDefault(x => x.CustomerId == customerId
                && x.ProductId == cartItem.ProductId);
                if (cartItemInDb == null)
                {
                    db.CartItems.Add(new CartItem()
                    {
                        TotalPrice = cartItem.TotalPrice,
                        Amount = cartItem.Amount,
                        ProductId = cartItem.ProductId,
                        CustomerId = customerId
                    });
                }
                else
                {
                    cartItemInDb.Amount += cartItem.Amount;
                    cartItemInDb.TotalPrice = (cartItem.TotalPrice / cartItem.Amount) * cartItemInDb.Amount;
                }
                
                db.SaveChanges();
            }
            catch(Exception ex) { 
            }
            
        }
    }
}

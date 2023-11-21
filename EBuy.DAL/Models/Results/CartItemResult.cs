using EBuy.DAL.Models.EF_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.DAL.Models.Results
{
    public class CartItemResult
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Customer Customer { get; set; }
        public string ProductName { get; set; }
        public string ProductDetail { get; set; }
        public string ImageName { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }
    }
}

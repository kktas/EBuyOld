using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.DAL.Models.Results
{
    public class SaleResult
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}

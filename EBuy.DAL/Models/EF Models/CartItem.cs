using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.DAL.Models.EF_Models
{
    public class CartItem
    {
        public int Id { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; } 
        public int CustomerId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.DAL.Models.EF_Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public string ImageName {get; set;}
        public string DetailText { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public double Price { get; set; }
        
        public List<Sale> Sales { get; set; }
        
        public List<CartItem> CartItems { get; set; }
        
    }
}

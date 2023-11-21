using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.DAL.Models.EF_Models
{
    public class Customer
    {
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
        
        public List<CartItem> CartItems { get; set; }
        
        public List<Sale> Sales { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.DAL.Models.EF_Models
{
    public class Brand
    {
        [Key]
        public int Id{ get; set; }
        public string BrandName { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }

        
        public List<Product> Products { get; set; }
    }
}

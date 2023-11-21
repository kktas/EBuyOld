using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBuy.Website.Models.Identity
{
    public class Login
    {
        [EmailAddress(ErrorMessage ="Email is not valid")]
        public string Email { get; set; }
        [MinLength(6, ErrorMessage = "Password cannot be shorter than 6 characters"), MaxLength(50,ErrorMessage ="Password cannot be longer than 50 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

using EBuy.DAL.Models.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBuy.Website.Models.Identity
{
    public class Register
    {
        [Required]
        [Display(Name = "First Name")]
        [MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        [MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password cannot be shorter than 6 characters"), MaxLength(50, ErrorMessage = "Password cannot be longer than 50 characters")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Re-enter Password")]
        [DataType(DataType.Password)]
        [MinLength(6), MaxLength(50)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string PasswordRepeat { get; set; }

        [Required]
        public int Role { get; set; }

        public List<RoleResult> Roles { get; set; }
    }
}

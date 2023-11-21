using EBuy.DAL.Models.EF_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.DAL.Models.Results
{
    public class UserResult
    {
        public bool Succeeded { get; set; } = false;
        public string RoleName = "";
        public User User { get; set; } = null;
    }
}

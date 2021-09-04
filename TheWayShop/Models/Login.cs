using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWayShop.Models
{
    public class Login
    {
        // Login page passing values creadentails 
        public int Id { get; set; }

        [Display(Name = "LoginUser")]
        public string LoginUser { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        
    }
}

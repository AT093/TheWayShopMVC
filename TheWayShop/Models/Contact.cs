using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWayShop.Models
{
    public class Contact
    {
        // contact us page and its columns passing values
        public int Id { get; set; }


        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        

        [Display(Name = "Address")]
        public string Address { get; set; }


        [Display(Name = "Message")]
        public string Message { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWayShop.Models
{
    public class YourItems
    {
        // your items page 
        public int Id { get; set; }
        // this will display item record 
        [Display(Name = "Item")]
        public string Item { get; set; }
        // will display brand from database
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Price")]
        public string Price { get; set; }
        // this key is coming from another table that is called foreign key
        [Display(Name = "UserId")]
        public int UserId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TheWayShop.Models
{
    public class Items
    {
        // values passing in items page
        public int Id { get; set; }

        [Display(Name = "Item")]
        public string Item { get; set; }

        [Display(Name = "Brand")]
        public string Brand { get; set; }
        
        [Display(Name = "Category")]
        public string Category { get; set; }
        
        [Display(Name = "Price")]
        public string Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PizzaShopOnline.BAU.Site.Models
{
    public class Delivery
    {
        private const string V = @"decimal{10}";

        [Required(ErrorMessage = "Enter address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [MinLength(2)]
        [MaxLength(20)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter telephone Number")]
        [RegularExpression(@"([0-9]{10})$", ErrorMessage = "Not a valid Telephone number")]
        [Display(Name= "Telephone")]
        public Double Telephone { get; set; }
    }
}

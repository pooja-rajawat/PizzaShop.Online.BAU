using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PizzaShopOnline.BAU.Site.Models
{
    public class Delivery
    {
        [Required(ErrorMessage = "Must Select Toppings")]
        public List<string> Toppings { get; set; }

        [Required(ErrorMessage = "Enter address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter telephone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Telephone number")]
        public Double Telephone { get; set; }
    }
}

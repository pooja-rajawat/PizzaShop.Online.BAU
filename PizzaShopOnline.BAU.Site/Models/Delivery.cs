using System.ComponentModel.DataAnnotations;

namespace PizzaShopOnline.BAU.Site.Models
{
    public class Delivery
    {

        [Required(ErrorMessage = "Enter address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [MinLength(2, ErrorMessage = "Enter name between 2 and 20 characters")]
        [MaxLength(20)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [RegularExpression(@"([0-9]{10})$", ErrorMessage = "Not a valid Telephone number")]
        [Required(ErrorMessage = "Enter telephone Number")]
        [Display(Name = "Telephone")]
        public double Telephone { get; set; }

    }
}

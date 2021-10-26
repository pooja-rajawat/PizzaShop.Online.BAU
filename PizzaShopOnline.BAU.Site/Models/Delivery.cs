using System.ComponentModel.DataAnnotations;

namespace PizzaShopOnline.BAU.Site.Models
{
    public class Delivery
    {

        [Required(ErrorMessage = "Please enter address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [MinLength(2, ErrorMessage = "Please enter name between 2 and 20 characters")]
        [MaxLength(20)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [RegularExpression(@"([0-9]{10})$", ErrorMessage = "Not a valid Telephone number")]
        [Required(ErrorMessage = "Please enter telephone Number")]
        [Display(Name = "Telephone")]
        public double Telephone { get; set; }

    }
}

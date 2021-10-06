using PizzaShopOnline.BAU.Site.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PizzaShopOnline.BAU.Site.Utilities
{
    public class ValidateToppings : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            List<PizzaTopping> toppings = (List<PizzaTopping>)value;
            return toppings.Where(toppings => toppings.IsSelected == true).Any();
        }
    }
}

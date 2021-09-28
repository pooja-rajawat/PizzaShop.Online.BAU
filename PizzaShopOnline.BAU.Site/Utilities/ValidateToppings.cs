using PizzaShopOnline.BAU.Site.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShopOnline.BAU.Site.Utilities
{
    public class ValidateToppings : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            List<PizzaTopping> Toppings = (List<PizzaTopping>)value;
            return Toppings.Where(Topping => Topping.IsSelected == true).Any();
        }
    }
}

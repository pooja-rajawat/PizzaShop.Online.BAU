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
            Dictionary<ToppingType, bool> ToppingList = (Dictionary<ToppingType, bool>)value;
            return ToppingList.ContainsValue(true);
        }
    }
}

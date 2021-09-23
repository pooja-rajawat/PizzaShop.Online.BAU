using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PizzaShopOnline.BAU.Site.Utilities;

namespace PizzaShopOnline.BAU.Site.Models
{
    public enum PizzaSize
    {
        SMALL,
        MEDIUM,
        LARGE,
    }
    public enum ToppingType
    {
        EXTRA_CHEESE,
        ONIONS,
        MUSHROOMS,
        BACON,
        PEPPERONI
    }
    public enum BaseType
    {
        STUFFED_CRUST,
        CRACKER_CRUST,
        FLAT_BREAD_CRUST
    }
    public class PizzaModel
    {
        public string Name { get; set; }
        public PizzaSize Size { get; set; }
        public double CurrentPizzaBasePrice { get; set; }
        public double CurrentToppingPrice { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }

        [Required(ErrorMessage = "Please select base type")]
        public BaseType PizzaBase { get; set; }
        public Dictionary<BaseType, double> PizzaBasePrice { get; set; }

        [ValidateToppings(ErrorMessage = "You need to select atleast one topping")]
        public Dictionary<ToppingType, bool> ToppingList { get; set; }
        public Dictionary<ToppingType, double> ToppingPrice { get; set; }

    }
}

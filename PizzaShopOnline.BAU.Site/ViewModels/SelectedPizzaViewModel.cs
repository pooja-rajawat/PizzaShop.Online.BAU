using PizzaShopOnline.BAU.Site.Models;
using PizzaShopOnline.BAU.Site.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PizzaShopOnline.BAU.Site.ViewModels
{
    public class SelectedPizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(1, 3, ErrorMessage = "Please select size...")]
        public int SelectedPizzaSize { get; set; }
        public Size PizzaSize { get; set; }
        public List<PizzaSizeType> PizzaSizePrice { get; set; }

        [Range(1, 3, ErrorMessage = "Please select base...")]
        public int SelectedBaseType { get; set; }
        public BaseType PizzaBase { get; set; }
        public List<PizzaBaseType> PizzaBasePrice { get; set; }

        [ValidateToppings(ErrorMessage = "You need to select atleast one topping")]
        public List<PizzaTopping> Toppings { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

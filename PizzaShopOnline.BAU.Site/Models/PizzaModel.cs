using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PizzaShopOnline.BAU.Site.Utilities;

namespace PizzaShopOnline.BAU.Site.Models
{
    public enum Size
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

    public class ToppingTypeZ
    {
        public int Id { get; }
        public string Name { get; }

        private ToppingTypeZ(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static ToppingTypeZ Select = new ToppingTypeZ(-1, "Please select...");
        public static ToppingTypeZ ExtraCheese = new ToppingTypeZ(1, "Extra Cheese");
        public static ToppingTypeZ Onions = new ToppingTypeZ(2, "Onions");
        public static ToppingTypeZ Mushrooms = new ToppingTypeZ(3, "Mushrooms");
        public static ToppingTypeZ Bacon = new ToppingTypeZ(4, "Bacon");
        public static ToppingTypeZ Pepperoni = new ToppingTypeZ(5, "Pepperoni");
    }

    public enum BaseType
    {
        STUFFED_CRUST,
        CRACKER_CRUST,
        FLAT_BREAD_CRUST
    }
    public class PizzaTopping
    {
        public ToppingType ToppingType { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
    }
    public class PizzaBaseType
    {
        public BaseType BaseType { get; set; }
        public decimal Price { get; set; }
    }
    public class PizzaSizeType
    {
        public Size Size { get; set; }
        public decimal Price { get; set; }
    }
    public class PizzaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Size PizzaSize { get; set; }
        public IEnumerable<PizzaSizeType> PizzaSizePrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Please select base type")]
        public BaseType PizzaBase { get; set; }
        public IEnumerable<PizzaBaseType> PizzaBasePrice { get; set; }

        [ValidateToppings(ErrorMessage = "You need to select atleast one topping")]
        public IEnumerable<PizzaTopping> Toppings { get; set; }
    }
}

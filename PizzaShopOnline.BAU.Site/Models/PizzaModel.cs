using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PizzaShopOnline.BAU.Site.Utilities;

namespace PizzaShopOnline.BAU.Site.Models
{
    public class Size
    {
        public int Id { get; }
        public string Name { get; }

        private Size(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static readonly Size Select = new Size(-1, "Please select...");
        public static readonly Size Small = new Size(1, "Small");
        public static readonly Size Medium = new Size(2, "Medium");
        public static readonly Size Large = new Size(3, "Large");

        public static IEnumerable<Size> GetSizeList()
        {
            return new List<Size>() {
                Select,
                Small,
                Medium,
                Large
            };
        }

        public static IList<SelectListItem> GetSelectedListItem()
        {
            return GetSizeList().ToList().Select(item => new SelectListItem { Text = item.Name, Value = item.Id + "" }).ToList();
        }
    }

    public class ToppingType
    {
        public int Id { get; set; }
        public string Name { get; set; }

/*        public ToppingType() { }*/
        public ToppingType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static readonly ToppingType Empty = new ToppingType(-1, "");
        public static readonly ToppingType ExtraCheese = new ToppingType(1, "Extra Cheese");
        public static readonly ToppingType Onions = new ToppingType(2, "Onions");
        public static readonly ToppingType Mushrooms = new ToppingType(3, "Mushrooms");
        public static readonly ToppingType Bacon = new ToppingType(4, "Bacon");
        public static readonly ToppingType Pepperoni = new ToppingType(5, "Pepperoni");
    }

    public class BaseType
    {
        public int Id { get; }
        public string Name { get; }

        private BaseType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static readonly BaseType Select = new BaseType(-1, "Please select...");
        public static readonly BaseType StuffedCrust = new BaseType(1, "Stuffed Crust");
        public static readonly BaseType CrackerCrust = new BaseType(2, "Cracker Crust");
        public static readonly BaseType FlatBreadCrust = new BaseType(3, "Flat-bread Crust");

        public static IEnumerable<BaseType> GetBaseTypeList()
        {
            return new List<BaseType>() {
                Select,
                StuffedCrust,
                CrackerCrust,
                FlatBreadCrust
            };
        }

        public static IList<SelectListItem> GetSelectedListItem()
        {
            return GetBaseTypeList().ToList().Select(item => new SelectListItem { Text = item.Name, Value = item.Id + "" }).ToList();
        }
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

        [Range(1, 3, ErrorMessage = "Please select size...")]
        public int SelectedPizzaSize { get; set; }
        public Size PizzaSize { get; set; }
        public IEnumerable<PizzaSizeType> PizzaSizePrice { get; set; }

        [Range(1, 3, ErrorMessage = "Please select base...")]
        public int SelectedBaseType { get; set; }
        public BaseType PizzaBase { get; set; }
        public IEnumerable<PizzaBaseType> PizzaBasePrice { get; set; }

        [ValidateToppings(ErrorMessage = "You need to select atleast one topping")]
        public IEnumerable<PizzaTopping> Toppings { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

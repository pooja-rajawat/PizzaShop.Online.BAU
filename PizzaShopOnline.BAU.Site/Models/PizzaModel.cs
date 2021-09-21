using System;
using System.Collections.Generic;
using System.ComponentModel;

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
    public class PizzaModel
    {
        public string Name { get; set; }
        public PizzaSize Size { get; set; }
        public double Price { get; set; }
        public string BaseType { get; set; }
        public Dictionary<ToppingType, bool> ToppingCount { get; set; }
        public Dictionary<ToppingType, double> ToppingPrice { get; set; }

    }
}

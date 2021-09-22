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
        public double Price { get; set; }
        public BaseType PizzaBase { get; set; }
        public Dictionary<BaseType, double> PizzaBasePrice { get; set; }
        public Dictionary<ToppingType, bool> ToppingCount { get; set; }
        public Dictionary<ToppingType, double> ToppingPrice { get; set; }

    }
}

using PizzaShopOnline.BAU.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShopOnline.BAU.Site.ViewModels
{
    public class HomePageViewModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<PizzaTopping> Toppings { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaShopOnline.BAU.Site.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShopOnline.BAU.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SelectedPizza()
        {
            // DB
            PizzaModel PizzaModel = new PizzaModel();
            PizzaModel.Price = 20;
            PizzaModel.Name = "Margherita";
            PizzaModel.Size = PizzaSize.LARGE;
            PizzaModel.BaseType = "Thin Crust";
            PizzaModel.ToppingCount = new Dictionary<ToppingType, bool>()
            {
                { ToppingType.EXTRA_CHEESE, false },
                { ToppingType.ONIONS, false },
                { ToppingType.BACON, false },
                { ToppingType.MUSHROOMS, false },
                { ToppingType.PEPPERONI, false },
            };


            return View(PizzaModel);
        }

        [HttpPost]
        public IActionResult SelectedPizza(PizzaModel PizzaModel)
        {
            // DB
            PizzaModel.ToppingPrice = new Dictionary<ToppingType, double>()
            {
                { ToppingType.EXTRA_CHEESE, 1.0 },
                { ToppingType.ONIONS, 2.0 },
                { ToppingType.BACON, 3.0 },
                { ToppingType.MUSHROOMS, 4.0 },
                { ToppingType.PEPPERONI, 5.0 },
            };

            var Price = PizzaModel.Price;
            foreach( var Entry in PizzaModel.ToppingCount)
            {
                if(Entry.Value == true)
                {
                    Price += PizzaModel.ToppingPrice[Entry.Key];  
                }
            }
            PizzaModel.Price = Price;

            return View(PizzaModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

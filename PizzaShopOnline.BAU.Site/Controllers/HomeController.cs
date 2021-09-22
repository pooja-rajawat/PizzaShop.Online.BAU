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
            PizzaModel.PizzaBase = BaseType.FLAT_BREAD_CRUST;
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
        public IActionResult SelectedPizza(PizzaModel PizzaModel, string submit)
        {
            // DB
            PizzaModel.PizzaBasePrice = new Dictionary<BaseType, double>()
            {
                { BaseType.STUFFED_CRUST, 10.0 },
                { BaseType.CRACKER_CRUST, 15.0 },
                { BaseType.FLAT_BREAD_CRUST, 20.0 }
            };

            PizzaModel.ToppingPrice = new Dictionary<ToppingType, double>()
            {
                { ToppingType.EXTRA_CHEESE, 1.0 },
                { ToppingType.ONIONS, 2.0 },
                { ToppingType.BACON, 3.0 },
                { ToppingType.MUSHROOMS, 4.0 },
                { ToppingType.PEPPERONI, 5.0 },
            };

            var Price = PizzaModel.Price;
            Price += PizzaModel.PizzaBasePrice[PizzaModel.PizzaBase];
            foreach( var Entry in PizzaModel.ToppingCount)
            {
                if(Entry.Value == true)
                {
                    Price += PizzaModel.ToppingPrice[Entry.Key];  
                }
            }
            if (Price >= 20)
            {
                Price -= Price * 0.15;
            }
            PizzaModel.Price = Price;

            if (submit == "Update pizza")
            {
                return View(PizzaModel);
            }
             else
            {
                return RedirectToAction("DeliveryForm","Delivery");
            }
           
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

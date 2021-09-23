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

        [HttpGet]
        public IActionResult SelectedPizza()
        {
            //Previous Page
            PizzaModel PizzaModel = new PizzaModel
            {
                Name = "Margherita",
                Size = PizzaSize.LARGE,
                PizzaBase = BaseType.FLAT_BREAD_CRUST,
                ToppingList = new Dictionary<ToppingType, bool>()
                {
                    { ToppingType.EXTRA_CHEESE, false },
                    { ToppingType.ONIONS, true },
                    { ToppingType.BACON, false },
                    { ToppingType.MUSHROOMS, false },
                    { ToppingType.PEPPERONI, false },
                },
                ToppingPrice = new Dictionary<ToppingType, double>()
                {
                    { ToppingType.EXTRA_CHEESE, 1.0 },
                    { ToppingType.ONIONS, 2.0 },
                    { ToppingType.BACON, 3.0 },
                    { ToppingType.MUSHROOMS, 4.0 },
                    { ToppingType.PEPPERONI, 5.0 },
                },
                PizzaBasePrice = new Dictionary<BaseType, double>()
                {
                    { BaseType.STUFFED_CRUST, 10.0 },
                    { BaseType.CRACKER_CRUST, 15.0 },
                    { BaseType.FLAT_BREAD_CRUST, 20.0 }
                },
                TotalPrice = 32,
            };
            PizzaModel.CurrentPizzaBasePrice = PizzaModel.PizzaBasePrice[PizzaModel.PizzaBase];
            double ToppingPrice = 0;    
            PizzaModel.ToppingList.Where(Topping => Topping.Value).ToList().ForEach(Entry =>
            {
                ToppingPrice += PizzaModel.ToppingPrice[Entry.Key];
            });
            PizzaModel.CurrentToppingPrice = ToppingPrice;
            PizzaModel.DiscountPrice = PizzaModel.TotalPrice >= 20.0 ? (PizzaModel.TotalPrice - (PizzaModel.TotalPrice * 0.15)) : PizzaModel.TotalPrice;
            PizzaModel.DiscountPrice = Math.Round(PizzaModel.DiscountPrice, 2);

            return View(PizzaModel);
        }

        [HttpPost]
        public IActionResult SelectedPizza(PizzaModel PizzaModel, string submit)
        {
            if (!ModelState.IsValid)
            {
                return View(PizzaModel);
            }

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

            var TotalPrice = PizzaModel.TotalPrice;
            TotalPrice = TotalPrice - PizzaModel.CurrentPizzaBasePrice - PizzaModel.CurrentToppingPrice;
            TotalPrice += PizzaModel.PizzaBasePrice[PizzaModel.PizzaBase];
            PizzaModel.ToppingList.Where(Topping => Topping.Value).ToList().ForEach(Entry =>
            {
                TotalPrice += PizzaModel.ToppingPrice[Entry.Key];
            });
            TotalPrice = TotalPrice >= 20.0 ? (TotalPrice - (TotalPrice * 0.15)) : TotalPrice;
            PizzaModel.DiscountPrice = Math.Round(TotalPrice, 2);

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

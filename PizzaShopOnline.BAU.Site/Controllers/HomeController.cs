using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaShopOnline.BAU.Site.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PizzaShopOnline.BAU.Site.Repositories;

namespace PizzaShopOnline.BAU.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private PizzaRepository _pizzaRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _pizzaRepository = new PizzaRepository();
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
        public IActionResult SelectedPizza(Guid pizzaId)
        {
            PizzaModel PizzaModel = _pizzaRepository.GetPizzaModel(pizzaId);
            PizzaModel.TotalPrice = _pizzaRepository.GetTotalPrice(PizzaModel.PizzaSize, PizzaModel.PizzaBase, PizzaModel.Toppings);
            PizzaModel.DiscountPrice = _pizzaRepository.GetDiscountPrice(PizzaModel.TotalPrice);

            return View(PizzaModel);
        }

        [HttpPost]
        public IActionResult SelectedPizza(PizzaModel PizzaModel)
        {
            if (!ModelState.IsValid)
            {
                return View(PizzaModel);
            }

            PizzaModel.PizzaBasePrice = _pizzaRepository.GetPizzaBasePrice();
            PizzaModel.PizzaSizePrice = _pizzaRepository.GetPizzaSizePrice();
            PizzaModel.TotalPrice = _pizzaRepository.GetTotalPrice(PizzaModel.PizzaSize, PizzaModel.PizzaBase, PizzaModel.Toppings);
            PizzaModel.DiscountPrice = _pizzaRepository.GetDiscountPrice(PizzaModel.TotalPrice);

            return View(PizzaModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

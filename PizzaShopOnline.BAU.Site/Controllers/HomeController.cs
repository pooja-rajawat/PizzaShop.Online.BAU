using Microsoft.AspNetCore.Mvc;
using PizzaShopOnline.BAU.Site.Models;
using PizzaShopOnline.BAU.Site.Repositories;
using PizzaShopOnline.BAU.Site.Services;
using System.Diagnostics;

namespace PizzaShopOnline.BAU.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public HomeController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            var model = _pizzaService.GetPizzaList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SelectedPizza(int id)
        {
            PizzaModel PizzaModel = _pizzaService.GetPizzaModel(id);
            return View(PizzaModel);
        }

        [HttpPost]
        public IActionResult SelectedPizza(PizzaModel pizzaModel)
        {
            if (!ModelState.IsValid)
            {
                return View(pizzaModel);
            }

            var model = _pizzaService.UpdatePizza(pizzaModel);

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

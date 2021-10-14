using Microsoft.AspNetCore.Mvc;
using PizzaShopOnline.BAU.Site.Models;
using PizzaShopOnline.BAU.Site.Repositories;
using PizzaShopOnline.BAU.Site.Services;
using PizzaShopOnline.BAU.Site.ViewModels;
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
            SelectedPizzaViewModel selectedPizzaViewModel = _pizzaService.GetSelectedPizzaViewModel(id);
            return View(selectedPizzaViewModel);
        }

        [HttpPost]
        public IActionResult SelectedPizza(SelectedPizzaViewModel selectedPizzaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(selectedPizzaViewModel);
            }

            var model = _pizzaService.UpdatePizza(selectedPizzaViewModel);

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

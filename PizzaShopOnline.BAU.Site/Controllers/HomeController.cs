using Microsoft.AspNetCore.Mvc;
using PizzaShopOnline.BAU.Site.Models;
using PizzaShopOnline.BAU.Site.Repositories;
using System.Diagnostics;

namespace PizzaShopOnline.BAU.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;

        public HomeController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
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
        public IActionResult SelectedPizza(int id)
        {
            PizzaModel PizzaModel = _pizzaRepository.GetPizzaModel(id);
            return View(PizzaModel);
        }

        [HttpPost]
        public IActionResult SelectedPizza(PizzaModel pizzaModel)
        {
            if (!ModelState.IsValid)
            {
                return View(pizzaModel);
            }

            var model = _pizzaRepository.UpdatePizza(pizzaModel);

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

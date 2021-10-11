using PizzaShopOnline.BAU.Site.Models;
using PizzaShopOnline.BAU.Site.Repositories;
using PizzaShopOnline.BAU.Site.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PizzaShopOnline.BAU.Site.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IEnumerable<HomePageViewModel> GetPizzaList()
        {
            var pizzas = _pizzaRepository.GetPizzaList();

            var result = pizzas.Select(pizza => new HomePageViewModel
            {
                Name = pizza.Name,
                ImageUrl = pizza.ImageUrl,
                PizzaId = pizza.Id
            });

            return result;
        }

        public PizzaModel GetPizzaModel(int pizzaId)
        {
            return _pizzaRepository.GetPizzaModel(pizzaId);
        }

        public PizzaModel UpdatePizza(PizzaModel pizzaModel)
        {
            return _pizzaRepository.UpdatePizza(pizzaModel);
        }
    }
}

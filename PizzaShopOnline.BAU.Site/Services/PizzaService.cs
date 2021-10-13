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

        public SelectedPizzaViewModel UpdatePizza(SelectedPizzaViewModel selectedPizzaViewModel)
        {

            PizzaModel pizzaModel = new PizzaModel
            {
                Name = selectedPizzaViewModel.Name,
                Id = selectedPizzaViewModel.Id,
                DiscountPrice = selectedPizzaViewModel.DiscountPrice,
                PizzaBase = selectedPizzaViewModel.PizzaBase,
                PizzaBasePrice = selectedPizzaViewModel.PizzaBasePrice,
                PizzaSize = selectedPizzaViewModel.PizzaSize,
                PizzaSizePrice = selectedPizzaViewModel.PizzaSizePrice,
                SelectedBaseType = selectedPizzaViewModel.SelectedBaseType,
                SelectedPizzaSize = selectedPizzaViewModel.SelectedPizzaSize,
                Toppings = selectedPizzaViewModel.Toppings,
                TotalPrice = selectedPizzaViewModel.TotalPrice
            };
            pizzaModel = _pizzaRepository.UpdatePizza(pizzaModel);
            SelectedPizzaViewModel result = new SelectedPizzaViewModel
            {
                Name = pizzaModel.Name,
                Id = pizzaModel.Id,
                DiscountPrice = pizzaModel.DiscountPrice,
                PizzaBase = pizzaModel.PizzaBase,
                PizzaBasePrice = (List<PizzaBaseType>)pizzaModel.PizzaBasePrice,
                PizzaSize = pizzaModel.PizzaSize,
                PizzaSizePrice = (List<PizzaSizeType>)pizzaModel.PizzaSizePrice,
                SelectedBaseType = pizzaModel.SelectedBaseType,
                SelectedPizzaSize = pizzaModel.SelectedPizzaSize,
                Toppings = (List<PizzaTopping>)pizzaModel.Toppings,
                TotalPrice = pizzaModel.TotalPrice
            };
            return result;
        }

        public SelectedPizzaViewModel GetSelectedPizzaViewModel(int pizzaId)
        {
            PizzaModel pizzaModel = GetPizzaModel(pizzaId);
            SelectedPizzaViewModel result = new SelectedPizzaViewModel
            {
                Name = pizzaModel.Name,
                Id = pizzaModel.Id,
                DiscountPrice = pizzaModel.DiscountPrice,
                PizzaBase = pizzaModel.PizzaBase,
                PizzaBasePrice = (List<PizzaBaseType>)pizzaModel.PizzaBasePrice,
                PizzaSize = pizzaModel.PizzaSize,
                PizzaSizePrice = (List<PizzaSizeType>)pizzaModel.PizzaSizePrice,
                SelectedBaseType = pizzaModel.SelectedBaseType,
                SelectedPizzaSize = pizzaModel.SelectedPizzaSize,
                Toppings = (List<PizzaTopping>)pizzaModel.Toppings,
                TotalPrice = pizzaModel.TotalPrice
            };
            return result;
        }
    }
}

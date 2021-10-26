using PizzaShopOnline.BAU.Site.Models;
using PizzaShopOnline.BAU.Site.ViewModels;
using System.Collections.Generic;

namespace PizzaShopOnline.BAU.Site.Services
{
    public interface IPizzaService 
    {
        IEnumerable<HomePageViewModel> GetPizzaList();
        PizzaModel GetPizzaModel(int pizzaId);
        SelectedPizzaViewModel UpdatePizza(SelectedPizzaViewModel selectedPizzaViewModel);
        SelectedPizzaViewModel GetSelectedPizzaViewModel(int pizzaId);

        DeliveryPageViewModel GetDeliveryPageViewModel(int id);
    }
}

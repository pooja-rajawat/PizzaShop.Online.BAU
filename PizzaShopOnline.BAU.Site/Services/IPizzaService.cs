using PizzaShopOnline.BAU.Site.ViewModels;
using System.Collections.Generic;

namespace PizzaShopOnline.BAU.Site.Services
{
    public interface IPizzaService 
    {
        IEnumerable<HomePageViewModel> GetPizzaList();

        DeliveryPageViewModel GetDeliveryPageViewModel(int id);
    }
}

using PizzaShopOnline.BAU.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShopOnline.BAU.Site.Services
{
   public interface IHomePageService
    {
        IEnumerable<HomePageViewModel> GetPizzaList();
    }
}

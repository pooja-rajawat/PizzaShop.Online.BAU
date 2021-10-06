using PizzaShopOnline.BAU.Site.Models;
using System.Collections.Generic;

namespace PizzaShopOnline.BAU.Site.Repositories
{
    public interface IPizzaRepository
    {
        PizzaModel GetPizzaModel(int pizzaId);
        PizzaModel UpdatePizza(PizzaModel pizzaModel);
        IEnumerable<PizzaModel> GetPizzaList();
    }
}
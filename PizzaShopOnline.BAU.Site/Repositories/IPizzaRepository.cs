using PizzaShopOnline.BAU.Site.Models;
using System;

namespace PizzaShopOnline.BAU.Site.Repositories
{
    public interface IPizzaRepository
    {
        PizzaModel GetPizzaModel(int pizzaId);
        PizzaModel UpdatePizza(PizzaModel pizzaModel);
    }
}
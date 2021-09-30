using PizzaShopOnline.BAU.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaShopOnline.BAU.Site.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private IEnumerable<PizzaTopping> GetPizzaToppings()
        {
            return new List<PizzaTopping>() {
                new PizzaTopping(){
                    ToppingType = ToppingType.EXTRA_CHEESE,
                    Price = 2.0M,
                    IsSelected = false
                },
                new PizzaTopping(){
                    ToppingType = ToppingType.BACON,
                    Price = 4.0M,
                    IsSelected = false
                },
                new PizzaTopping(){
                    ToppingType = ToppingType.MUSHROOMS,
                    Price = 6.0M,
                    IsSelected = false
                },
                new PizzaTopping(){
                    ToppingType = ToppingType.ONIONS,
                    Price = 8.0M,
                    IsSelected = false
                },
                new PizzaTopping(){
                    ToppingType = ToppingType.PEPPERONI,
                    Price = 10.0M,
                    IsSelected = false
                },
            };
        }

        private IEnumerable<PizzaBaseType> GetPizzaBasePrice()
        {
            return new List<PizzaBaseType>(){
                new PizzaBaseType() {
                    BaseType = BaseType.CRACKER_CRUST,
                    Price = 10.0M
                },
                new PizzaBaseType() {
                    BaseType = BaseType.STUFFED_CRUST,
                    Price = 15.0M
                },
                new PizzaBaseType() {
                    BaseType = BaseType.FLAT_BREAD_CRUST,
                    Price = 20.0M
                }
            };
        }

        private IEnumerable<PizzaSizeType> GetPizzaSizePrice()
        {
            return new List<PizzaSizeType>(){
                new PizzaSizeType() {
                    Size = Size.SMALL,
                    Price = 4.0M
                },
                new PizzaSizeType() {
                    Size = Size.MEDIUM,
                    Price = 7.0M
                },
                new PizzaSizeType() {
                    Size = Size.LARGE,
                    Price = 10.0M
                }
            };
        }

        private decimal GetTotalPrice(Size PizzaSize, BaseType PizzaBase, IEnumerable<PizzaTopping> Toppings)
        {
            var PizzaSizePrice = GetPizzaSizePrice();
            var PizzaBasePrice = GetPizzaBasePrice();
            decimal SizeTotalPrice = PizzaSizePrice.Where(SizePrice => SizePrice.Size == PizzaSize).ToList().First().Price;
            decimal BaseTotalPrice = PizzaBasePrice.Where(BasePrice => BasePrice.BaseType == PizzaBase).ToList().First().Price;
            decimal PizzaToppingsPrice = decimal.Zero;
            Toppings.Where(Toppings => Toppings.IsSelected).ToList().ForEach(Toppings =>
            {
                PizzaToppingsPrice = decimal.Add(PizzaToppingsPrice, Toppings.Price);
            });
            decimal TotalPrice = decimal.Add(BaseTotalPrice, PizzaToppingsPrice);
            TotalPrice = decimal.Add(TotalPrice, SizeTotalPrice);

            return TotalPrice;
        }

        private decimal GetDiscountPrice(decimal TotalPrice)
        {
            decimal DiscountPrice = TotalPrice < 20.0M ? TotalPrice : (TotalPrice - decimal.Multiply(TotalPrice, 0.15M));
            DiscountPrice = Math.Round(DiscountPrice, 2);

            return DiscountPrice;
        }

        public PizzaModel GetPizzaModel(int pizzaId)
        {
            var selectedPizza = GetPizzaList().FirstOrDefault(pizza => pizza.Id == pizzaId);
            return selectedPizza;
        }

        public PizzaModel UpdatePizza(PizzaModel pizzaModel)
        {
            pizzaModel.PizzaBasePrice = GetPizzaBasePrice();
            pizzaModel.PizzaSizePrice = GetPizzaSizePrice();
            pizzaModel.TotalPrice = GetTotalPrice(pizzaModel.PizzaSize, pizzaModel.PizzaBase, pizzaModel.Toppings);
            pizzaModel.DiscountPrice = GetDiscountPrice(pizzaModel.TotalPrice);

            return pizzaModel;
        }

        public IEnumerable<PizzaModel> GetPizzaList()
        {
            var result = new List<PizzaModel>();

            result.Add(
                new PizzaModel
                {
                    Id = 1,
                    Name = "Margherita",
                    PizzaSize = Size.MEDIUM,
                    PizzaSizePrice = GetPizzaSizePrice(),
                    PizzaBase = BaseType.FLAT_BREAD_CRUST,
                    PizzaBasePrice = GetPizzaBasePrice(),
                    Toppings = GetPizzaToppings()
                });
            return result;
        }
    }
}

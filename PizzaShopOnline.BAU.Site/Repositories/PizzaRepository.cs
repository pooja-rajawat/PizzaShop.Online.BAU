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
                    ToppingType = ToppingType.ExtraCheese,
                    Price = 2.0M,
                    IsSelected = false
                },
                new PizzaTopping(){
                    ToppingType = ToppingType.Bacon,
                    Price = 4.0M,
                    IsSelected = false
                },
                new PizzaTopping(){
                    ToppingType = ToppingType.Mushrooms,
                    Price = 6.0M,
                    IsSelected = false
                },
                new PizzaTopping(){
                    ToppingType = ToppingType.Onions,
                    Price = 8.0M,
                    IsSelected = false
                },
                new PizzaTopping(){
                    ToppingType = ToppingType.Pepperoni,
                    Price = 10.0M,
                    IsSelected = false
                },
            };
        }

        private IEnumerable<PizzaBaseType> GetPizzaBasePrice()
        {
            return new List<PizzaBaseType>(){
                new PizzaBaseType() {
                    BaseType = BaseType.Select,
                    Price = decimal.Zero
                },
                new PizzaBaseType() {
                    BaseType = BaseType.CrackerCrust,
                    Price = 10.0M
                },
                new PizzaBaseType() {
                    BaseType = BaseType.StuffedCrust,
                    Price = 15.0M
                },
                new PizzaBaseType() {
                    BaseType = BaseType.FlatBreadCrust,
                    Price = 20.0M
                }
            };
        }

        private IEnumerable<PizzaSizeType> GetPizzaSizePrice()
        {
            return new List<PizzaSizeType>(){
                new PizzaSizeType() {
                    Size = Size.Select,
                    Price = decimal.Zero
                },
                new PizzaSizeType() {
                    Size = Size.Small,
                    Price = 4.0M
                },
                new PizzaSizeType() {
                    Size = Size.Medium,
                    Price = 7.0M
                },
                new PizzaSizeType() {
                    Size = Size.Large,
                    Price = 10.0M
                }
            };
        }

        private decimal GetTotalPrice(Size pizzaSize, BaseType pizzaBase, IEnumerable<PizzaTopping> toppings)
        {
            var pizzaSizePrice = GetPizzaSizePrice();
            var pizzaBasePrice = GetPizzaBasePrice();
            decimal sizeTotalPrice = pizzaSizePrice.FirstOrDefault(SizePrice => SizePrice.Size == pizzaSize).Price;
            decimal baseTotalPrice = pizzaBasePrice.FirstOrDefault(BasePrice => BasePrice.BaseType == pizzaBase).Price;
            decimal pizzaToppingsPrice = decimal.Zero;
            toppings.Where(Toppings => Toppings.IsSelected).ToList().ForEach(Toppings =>
            {
                pizzaToppingsPrice = decimal.Add(pizzaToppingsPrice, Toppings.Price);
            });
            decimal totalPrice = decimal.Add(baseTotalPrice, pizzaToppingsPrice);
            totalPrice = decimal.Add(totalPrice, sizeTotalPrice);

            return totalPrice;
        }

        private decimal GetDiscountPrice(decimal totalPrice)
        {
            decimal discountPrice = totalPrice < 20.0M ? totalPrice : (totalPrice - decimal.Multiply(totalPrice, 0.15M));
            discountPrice = Math.Round(discountPrice, 2);

            return discountPrice;
        }

        public PizzaModel GetPizzaModel(int pizzaId)
        {
            var selectedPizza = GetPizzaList().FirstOrDefault(pizza => pizza.Id == pizzaId);
            return selectedPizza;
        }

        public PizzaModel UpdatePizza(PizzaModel pizzaModel)
        {
            pizzaModel.PizzaSize = Size.GetSizeList().First(item => item.Id == pizzaModel.SelectedPizzaSize);
            pizzaModel.PizzaBase = BaseType.GetBaseTypeList().First(item => item.Id == pizzaModel.SelectedBaseType);
            pizzaModel.PizzaBasePrice = GetPizzaBasePrice();
            pizzaModel.PizzaSizePrice = GetPizzaSizePrice();
            pizzaModel.TotalPrice = GetTotalPrice(pizzaModel.PizzaSize, pizzaModel.PizzaBase, pizzaModel.Toppings);
            pizzaModel.DiscountPrice = GetDiscountPrice(pizzaModel.TotalPrice);

            return pizzaModel;
        }

        public IEnumerable<PizzaModel> GetPizzaList()
        {
            var result = new List<PizzaModel>
            {
                new PizzaModel
                {
                    Id = 1,
                    Name = "Margherita",
                    PizzaSize = Size.Select,
                    PizzaSizePrice = GetPizzaSizePrice(),
                    PizzaBase = BaseType.Select,
                    PizzaBasePrice = GetPizzaBasePrice(),
                    Toppings = GetPizzaToppings(),
                    ImageUrl = "/images/Margherita.jpg"
                }
                
                ,
                new PizzaModel

                {
                    Id = 2,
                    Name = "Veggie Supreme",
                    PizzaSize = Size.Select,
                    PizzaSizePrice = GetPizzaSizePrice(),
                    PizzaBase = BaseType.Select,
                    PizzaBasePrice = GetPizzaBasePrice(),
                    Toppings = GetPizzaToppings(),
                    ImageUrl = "/images/VeggieSupreme.jpg"
                },
                 new PizzaModel

                {
                    Id = 3,
                    Name = "Tandoori Paneer",
                    PizzaSize = Size.Select,
                    PizzaSizePrice = GetPizzaSizePrice(),
                    PizzaBase = BaseType.Select,
                    PizzaBasePrice = GetPizzaBasePrice(),
                    Toppings = GetPizzaToppings(),
                    ImageUrl = "/images/Tandoori Paneer.jpg"
                },
                  new PizzaModel

                {
                    Id = 4,
                    Name = "Veg Kebab Surprise",
                    PizzaSize = Size.Select,
                    PizzaSizePrice = GetPizzaSizePrice(),
                    PizzaBase = BaseType.Select,
                    PizzaBasePrice = GetPizzaBasePrice(),
                    Toppings = GetPizzaToppings(),
                    ImageUrl = "/images/VegKebabSurprise.jpg"
                },
                   new PizzaModel

                {
                    Id = 5,
                    Name = "Corn And cheese",
                    PizzaSize = Size.Select,
                    PizzaSizePrice = GetPizzaSizePrice(),
                    PizzaBase = BaseType.Select,
                    PizzaBasePrice = GetPizzaBasePrice(),
                    Toppings = GetPizzaToppings(),
                    ImageUrl = "/images/cornAndcheese.jpg"
                },
                    new PizzaModel

                {
                    Id = 6,
                    Name = "Chicken Supreme",
                    PizzaSize = Size.Select,
                    PizzaSizePrice = GetPizzaSizePrice(),
                    PizzaBase = BaseType.Select,
                    PizzaBasePrice = GetPizzaBasePrice(),
                    Toppings = GetPizzaToppings(),
                    ImageUrl = "/images/ChickenSupreme.jpg"
                }

            };
            return result;
        }
    }
}

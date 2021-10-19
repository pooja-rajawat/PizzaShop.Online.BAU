using PizzaShopOnline.BAU.Site.Models;


namespace PizzaShopOnline.BAU.Site.ViewModels
{
    public class DeliveryPageViewModel
    {
        public string PizzaImageUrl { get; set; }
        public string PizzaName { get; set; }
        public Delivery PizzaModelItems { get; set; }
    }

}

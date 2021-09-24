
namespace PizzaShopOnline.BAU.Site.Models
{
    public enum PizzaSize
    {
        SMALL_PAN,
        MEDIUM_PAN,
        LARGE_PAN,
    }
    public class HomePageModel
    {
        public PizzaSize Size { get; set; }
    }
}

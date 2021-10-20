using Microsoft.AspNetCore.Mvc;
using PizzaShopOnline.BAU.Site.ViewModels;
using PizzaShopOnline.BAU.Site.Services;

namespace PizzaShopOnline.BAU.Site.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IPizzaService _deliveryPizzaService;

        public DeliveryController( IPizzaService deliveryPizzaService)
        {
            _deliveryPizzaService = deliveryPizzaService;
        }

        [HttpGet]
        public ActionResult DeliveryForm( int id)
        {             
            var deliveryPizzaModel = _deliveryPizzaService.GetPizzaModel(id);

            return View(deliveryPizzaModel);

        }

        [HttpPost]
        public ActionResult DeliveryForm( DeliveryPageViewModel account)
        {
            if (!ModelState.IsValid)
            {            
                return View(account);
            }

            return RedirectToAction("Success","Delivery");
           
        }

        public ActionResult Success()
        {
            return View();
        }
        
    }
}

 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaShopOnline.BAU.Site.Models;

namespace PizzaShopOnline.BAU.Site.Controllers
{
    public class DeliveryController : Controller
    {
        [HttpGet]
        public ActionResult DeliveryForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeliveryForm( Delivery account)
        {
            if (ModelState.IsValid)
            {
                ViewBag.account = account;
                return View("Success");
            }

            return View("DeliveryForm");
        }
       
    }
}

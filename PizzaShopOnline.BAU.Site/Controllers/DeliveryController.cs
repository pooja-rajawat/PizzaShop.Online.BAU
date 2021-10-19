﻿using Microsoft.AspNetCore.Mvc;
using PizzaShopOnline.BAU.Site.Models;
using PizzaShopOnline.BAU.Site.Repositories;
using PizzaShopOnline.BAU.Site.ViewModels;

namespace PizzaShopOnline.BAU.Site.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;

        public DeliveryController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        [HttpGet]
        public ActionResult DeliveryForm( int id)
        {
                
                PizzaModel deliveryPizzaModel = _pizzaRepository.GetPizzaModel(id);

                DeliveryPageViewModel deliveryPage = new DeliveryPageViewModel()
                { 
                    PizzaImageUrl = deliveryPizzaModel.ImageUrl,
                    PizzaName = deliveryPizzaModel.Name
                };
                
                return View(deliveryPage);
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

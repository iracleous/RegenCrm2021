using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegenCrm.Model;
using RegenCrm.Service;
using RegenCrmMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegenCrmMvc.Controllers
{
    public class CustomerController : Controller
    {

        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public CustomerController (IBasketService basketService, IProductService productService ) {
            _basketService = basketService;
            _productService = productService;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
           return View();
        }

        

        public ActionResult ShowBasket(int id)
        {
            
            int customerId = 4;
            Basket basket = _basketService.CreateBasket(customerId);

            List<ProductValue> productValues = _productService
                .ReadProduct(1, 100).
                Select(product => new ProductValue()
                {
                    Value = product.Id,
                    Text = product.Name
                }).ToList();

            BasketWithProducts basketWithProducts = new()
            {
                Basket = basket,
                Products = productValues,
                ProductIds = new List<int>()
            };


            return View(basketWithProducts);

        }
        [HttpPost]
      public IActionResult CreateBasket(BasketWithProducts basketWithProducts)
        {

            basketWithProducts.ProductIds.ForEach(productId =>
                _basketService.AddProduct2Basket(basketWithProducts.Basket.Id, productId));

            Basket basket = _basketService.GetBasket(basketWithProducts.Basket.Id);

            return View("GetBasket", basket);
        }

        public IActionResult GetBasket(Basket basket)
        {
             return View(basket);
        }
    }
}

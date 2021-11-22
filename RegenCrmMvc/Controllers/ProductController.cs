using Microsoft.AspNetCore.Mvc;
using RegenCrm.Model;
using RegenCrm.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegenCrmMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            List<Product> products = productService.ReadProduct(1, 10);
            return View(products);
        }

        public IActionResult Get(int id)
        {
            Product product = productService.ReadProduct(id);
            return View(product);
        }

    }
}

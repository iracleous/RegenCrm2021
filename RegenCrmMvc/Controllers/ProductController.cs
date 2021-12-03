using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RegenCrm.Model;
using RegenCrm.Service;
using RegenCrmMvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RegenCrmMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IHostEnvironment hostEnvironment;

        public ProductController(IProductService productService, IHostEnvironment hostEnvironment)
        {
            this.productService = productService;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> products = productService.ReadProduct(1, 10);
            return View(products);
        }

        public IActionResult Get(int id)
        {
            Product product = productService.ReadProduct(id);

            if (product == null) return NotFound();
            return View(product);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductWithImage productWithImage)
        {
            Product product = productWithImage.Product;
            var img = productWithImage.ProductImage;
            if (img != null)
            {
                var uniqueFileName = GetUniqueFileName(img.FileName);
                var uploads = Path.Combine(hostEnvironment.ContentRootPath + "\\wwwroot", "images");
                var filePath = Path.Combine(uploads, uniqueFileName);
                img.CopyTo(new FileStream(filePath, FileMode.Create));

                product.Description = uniqueFileName;
            }

                productService.CreateProduct(product);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {

            productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {

            productService.ChangeProductPrice(id, 4);
            return RedirectToAction(nameof(Index));
        }


        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }



    }
}

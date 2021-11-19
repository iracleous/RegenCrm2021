using RegenCrm.Model;
using RegenCrm.Service;
using System;
using System.Collections.Generic;

namespace RegenCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            

            using var crmDbContext = new CrmDbContext();
            var basketService = new BasketService(crmDbContext);

            var productService = new ProductService(crmDbContext);
            var products = productService.ReadProduct(1, 10);

            var customerService = new CustomerService(crmDbContext);
            var customers = customerService.ReadCustomer();

            var basket = basketService.CreateBasket(customers[0].Id);

            var basketProduct =  basketService.AddProduct2Basket(basket.Id, products[0].Id);




            Console.WriteLine("customer Id= " + customers[0].Id);
            Console.WriteLine("product Id= " + products[0].Id);
            Console.WriteLine("basketProduct Id= " + basketProduct.Id);
        }

      
        static void Test2()
        {
            //list all products
            using var crmDbContext = new CrmDbContext();
            var productService = new ProductService(crmDbContext);

            List<Product> products = productService.ReadProduct(1, 10);

            products.ForEach(product => Console.WriteLine($"id = {product.Id} name = {product.Name}"));
        }



        static void Test1()
        {
            //CRUD
            using var crmDbContext = new CrmDbContext();
            ICustomerService customerService = new CustomerService(crmDbContext);

            /*
            var customer = new Customer()
            {
                FirstName = "Manos",
                LastName = "E",
                Email = "e@gmail.com"
            };
         
            customerService.CreateCustomer(customer);
            */

            Customer customer = customerService.ReadCustomer(2);
            try
            {
                Console.WriteLine(customer.FirstName);
            }
            catch
            {
                Console.WriteLine("no such customer");
            }

            var productChips = new Product
            {
                Name = "Chips",
                Description = "Snacks",
                Price = 1.2m,
                InventoryQuantity = 10
            };


            var productService = new ProductService(crmDbContext);

            productService.CreateProduct(productChips);

            Console.WriteLine($"id= {productChips.Id}");
        }




    }
}

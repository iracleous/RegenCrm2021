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

            /*  ->use case
            A customer registers
            creates basket
            add product
            add product
            calculates the cost
            leaves
             */

            Customer customer = new Customer
            {
                FirstName = "Manos",
                LastName = "Di",
                Email = "manos@gmail.com",
                DateOfBirth = new DateTime(1970, 7, 1)
            };

            using var crmDbContext = new CrmDbContext();
            ICustomerService customerService = new CustomerService(crmDbContext);
            IBasketService basketService = new BasketService(crmDbContext);
            IProductService productService = new ProductService(crmDbContext);

            customerService.CreateCustomer(customer);

            Basket basket = basketService.CreateBasket(customer.Id);

            List<Product> products = productService.ReadProduct(1,10);

            basketService.AddProduct2Basket(basket.Id, products[0].Id);

            Console.WriteLine(basketService.GetTotalCost(basket.Id));

            basketService.AddProduct2Basket(basket.Id, products[0].Id);

            Console.WriteLine(basketService.GetTotalCost(basket.Id));

        }


        static void Test6()
        {
            using var crmDbContext = new CrmDbContext();
            var basketService = new BasketService(crmDbContext);
            Console.WriteLine(basketService.GetTotalCost(1));
        }


        static void Test5()
        {
            using var crmDbContext = new CrmDbContext();
            var basketService = new BasketService(crmDbContext);

            basketService.GetBasketProduct(1).ForEach(item => Console.WriteLine(item.Product.Name));

            basketService.RemoveProductFromBasket(1, 1);
            basketService.GetBasketProduct(1).ForEach(item => Console.WriteLine(item.Product.Name));

        }


        static void Test4()
        {
            using var crmDbContext = new CrmDbContext();
            var basketService = new BasketService(crmDbContext);

            decimal totalCost = basketService.GetTotalCost(1);
            Console.WriteLine(totalCost);
        }


        static void Test3()
        {

            using var crmDbContext = new CrmDbContext();
            var basketService = new BasketService(crmDbContext);

            var productService = new ProductService(crmDbContext);
            var products = productService.ReadProduct(1, 10);

            var customerService = new CustomerService(crmDbContext);
            var customers = customerService.ReadCustomer();

            var basket = basketService.CreateBasket(customers[0].Id);

            var basketProduct = basketService.AddProduct2Basket(basket.Id, products[0].Id);


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

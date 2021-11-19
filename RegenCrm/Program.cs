using RegenCrm.Model;
using RegenCrm.Service;
using System;

namespace RegenCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            //CRUD

            ICustomerService customerService = new CustomerService();

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
        }

      
    }
}

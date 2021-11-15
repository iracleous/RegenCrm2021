using RegenCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.Service
{
    public class CustomerService
    {

        public void CreateCustomer(Customer customer)
        {
           
            using var dbContext = new CrmDbContext();
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

        }



        public  Customer ReadCustomer(int id)
        {
            var dbContext = new CrmDbContext();
            Customer customer = dbContext.Customers.Find(id);

     

            return customer;
        }

    }
}

using RegenCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.Service
{
    public class CustomerService: ICustomerService
    {
        private readonly CrmDbContext dbContext;

        public CustomerService(CrmDbContext adbContext)
        {
            dbContext = adbContext;
        }

        public void CreateCustomer(Customer customer)
        {
            
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }
        public Customer ReadCustomer(int id)
        {
            
            Customer customer = dbContext.Customers.Find(id);
            return customer;
        }

        public List<Customer> ReadCustomer()
        {
            return dbContext.Customers.ToList();
        }
    }
}

using RegenCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.Service
{
    public interface ICustomerService
    {
        public void CreateCustomer(Customer customer);
        public Customer ReadCustomer(int id);

        public List<Customer> ReadCustomer();
    }
}

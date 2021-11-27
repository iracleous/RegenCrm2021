using Microsoft.AspNetCore.Mvc;
using RegenCrm.Model;
using RegenCrm.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegenCrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("/ping")]
        public string Ping()
        {
            return "it works";
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customerService.ReadCustomer();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return customerService.ReadCustomer(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public Customer Post([FromBody] Customer customer)
        {
            customerService.CreateCustomer(customer);
            return customer;
        }

        
    }
}

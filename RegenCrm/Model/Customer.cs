using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; } = true;
        public decimal Balance { get; set; }
        public virtual List<Basket> Baskets { get; set; }
    }
}

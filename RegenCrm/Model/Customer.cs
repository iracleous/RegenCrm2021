using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.Model
{
    public class Customer
    {
        public int Id { get; set; }
        //max length definition
        [MaxLength(50)]
        public string FirstName { get; set; }

        //second change
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsActive { get; set; } = true;
        public decimal Balance { get; set; }
        public virtual List<Basket> Baskets { get; set; }
    }
}

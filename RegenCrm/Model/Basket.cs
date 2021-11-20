using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.Model
{
    public class Basket
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TotalPrice { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [InverseProperty("Basket")]
        public virtual List<BasketProduct> BasketProducts { get; set; }
       
    }
}

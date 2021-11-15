using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.Model
{
    public class Basket
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public virtual List<BasketProduct> BasketProducts { get; set; }
       
    }
}

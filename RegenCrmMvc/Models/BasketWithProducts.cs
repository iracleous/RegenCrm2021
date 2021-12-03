using RegenCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegenCrmMvc.Models
{
    public class BasketWithProducts
    {
        public Basket Basket { get; set; }
        
        public List<ProductValue> Products { get; set; }
        public List<int> ProductIds { get; set; }
    }

    public class ProductValue
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }

}

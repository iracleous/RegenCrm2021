﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.Model
{
    public class BasketProduct
    {
        public int Id { get; set; }
        public Basket Basket { get; set; }
        public Product Product { get; set; }
    }
}

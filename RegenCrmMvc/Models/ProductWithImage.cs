using Microsoft.AspNetCore.Http;
using RegenCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegenCrmMvc.Models
{
    public class ProductWithImage
    {

        public Product Product { get; set; }
        public IFormFile ProductImage { set; get; }

    }
}

using RegenCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.dto
{
    public class ApiResponse<T> 
    {

        public T Data { get; set; }
        public int StatusCode { get; set; }

        public string Description { get; set; }

    }
}

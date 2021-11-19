using RegenCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.Service
{
    public interface IProductService
    {
        public Product CreateProduct(Product product);
        public Product ReadProduct(int id);
        public List<Product> ReadProduct(int pageCount, int pageSize);

        public Product UpdateProduct(int id, Product product);

        public bool DeleteProduct(int id);

    }
}

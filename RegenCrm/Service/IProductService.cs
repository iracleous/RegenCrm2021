using RegenCrm.dto;
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
        public ApiResponse<Product> CreateProduct(Product product);
           public Product ReadProduct(int id);
            public  List<Product> ReadProduct(int pageCount, int pageSize);

            public Product UpdateProduct(int productId, Product product);

        public Product ChangeProductPrice(int productId, decimal newPrice);

              public bool DeleteProduct(int id);



        //   public ApiResponse<Product> ReadProduct(int id);
        //    public  ApiResponse<List<Product>> ReadProduct(int pageCount, int pageSize);

        //     public ApiResponse<Product> UpdateProduct(int id, Product product);

        //     public ApiResponse<bool> DeleteProduct(int id);

    }
}

using RegenCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.Service
{
    public class ProductService : IProductService
    {
        private readonly CrmDbContext _db;

        public ProductService(CrmDbContext db)
        {
            _db = db;
        }
        public Product CreateProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return product;
        }

        public bool DeleteProduct(int id)
        {
            var dbProduct = _db.Products.Find(id);
            if (dbProduct == null) return false;
            _db.Products.Remove(dbProduct);
            return _db.SaveChanges() == 1;
        }

        public Product ReadProduct(int id)
        {
            return _db.Products.Find(id);
        }

        public List<Product> ReadProduct(int pageCount, int pageSize)
        {
            if (pageCount <= 0) pageCount = 1;
            if (pageSize <= 0 || pageSize > 20) pageSize = 20;
            return _db.Products
                .Skip((pageCount-1)*pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Product UpdateProduct(int id, Product product)
        {
            var dbProduct = _db.Products.Find(id);
            if (dbProduct == null) throw new KeyNotFoundException();
            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
            dbProduct.InventoryQuantity = product.InventoryQuantity;

            _db.SaveChanges();
            return dbProduct;
        }
    }
}

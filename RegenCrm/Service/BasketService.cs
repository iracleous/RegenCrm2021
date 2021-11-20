using Microsoft.EntityFrameworkCore;
using RegenCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.Service
{
    public class BasketService : IBasketService
    {
        private readonly CrmDbContext _db;

        public BasketService(CrmDbContext db)
        {
            _db = db;
        }
        public Basket CreateBasket(int customerId)
        {
            var customer = _db.Customers.Find(customerId);
            if (customer == null)
            {
                return null;
            }
            var basket = new Basket()
            {
                Customer = customer,
                DateTime = DateTime.Now
            };
            _db.Baskets.Add(basket);
            _db.SaveChanges();
            return basket;
        }
        public BasketProduct AddProduct2Basket(int basketId, int productId)
        {
            var basketDb = _db.Baskets.Find(basketId);
            if (basketDb == null)
            {
                return null;
            }
            var productDb = _db.Products.Find(productId);
            if (productDb == null)
            {
                return null;
            }
            var basketProduct = new BasketProduct
            {
                Basket = basketDb,
                Product = productDb
            };
            _db.BasketProducts.Add(basketProduct);
            _db.SaveChanges();
            return basketProduct;
        }

        public bool FinalizeBasket(int basketId)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalCost(int basketId)
        {

            //     Basket basketDb = _db.Baskets.Find(basketId);
            Basket basketDb = _db.Baskets
               .Include(p => p.BasketProducts)
               .ThenInclude(p1 => p1.Product)
               .Where(basket => basket.Id == basketId)
               .First();

            if (basketDb == null) return 0m;

            List<BasketProduct> basketProducts = basketDb.BasketProducts;

            return basketProducts[0].Product.Price;

        }

        public bool RemoveProductFromBasket(int basketId, int productId)
        {
            var basketDb = _db.Baskets.Find(basketId);
            if (basketDb == null)
            {
                return false;
            }
            var basketProductDb = _db.BasketProducts
                .Where(item => item.Basket == basketDb)
                .Where(item=> item.Product.Id == productId)
                .First();
            if (basketProductDb == null)
            {
                return false;
            }
            _db.BasketProducts.Remove(basketProductDb);
             
            return _db.SaveChanges() == 1;
        }

        public Basket GetBasket(int basketId)
        {
            return _db.Baskets.Find(basketId);
        }


        public List<BasketProduct> GetBasketProduct(int basketId)
        {
            return _db
                .BasketProducts
                .Where(item => item.Basket.Id == basketId)
                .Include(item => item.Product)
                .ToList();
        }
    }
}

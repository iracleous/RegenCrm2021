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
            return _db
                .BasketProducts
                .Where(bItem => bItem.Basket.Id == basketId)
                .Sum(bItem => bItem.Product.Price);
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
                .FirstOrDefault();
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

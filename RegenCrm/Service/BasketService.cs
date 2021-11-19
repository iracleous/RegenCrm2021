﻿using RegenCrm.Model;
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
            Customer customer = _db.Customers.Find(customerId);
            if (customer == null) return null;
            var basket = new Basket() { Customer = customer, DateTime=DateTime.Now };
            _db.Baskets.Add(basket);
            _db.SaveChanges();
            return basket;

        }


        public BasketProduct AddProduct2Basket(int basketId, int productId)
        {
            Basket basketDb = _db.Baskets.Find(basketId);
            if (basketDb == null) return null;
            Product productDb = _db.Products.Find(productId);
            if (productDb == null) return null;

            BasketProduct basketProduct = new BasketProduct { Basket = basketDb, Product = productDb };
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
            //Basket basketDb = _db.Baskets.Find(basketId);
            //if (basketDb == null) return 0m;

            //List<BasketProduct> basketProducts = basketDb.BasketProducts;

            return 0m;

        }

        public bool RemoveProductFromBasket(int basketId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}

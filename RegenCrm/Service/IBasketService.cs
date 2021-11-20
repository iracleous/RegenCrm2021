using RegenCrm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.Service
{
    public interface IBasketService
    {
        public Basket CreateBasket(int customerId);

        public BasketProduct AddProduct2Basket(int basketId, int productId);

        public bool RemoveProductFromBasket(int basketId, int productId);
        public decimal GetTotalCost(int basketId);

        public bool FinalizeBasket(int basketId);

        public Basket GetBasket(int basketId);

        public List<BasketProduct> GetBasketProduct(int basketId);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMBusinessLogic.Model
{
    public class ShopComputerModel
    {
        Generator generator = new Generator();
        Random rnd = new Random();
        public List<CashDesk> CashDesks { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Check> Checks { get; set; }
        public List<Sell> Sells { get; set; }
        public Queue<Seller> Sellers { get; set; }

        public ShopComputerModel()
        {
            var sellers = generator.GetNewSellers(20);
            generator.GetNewProducts(1000);
            generator.GetNewCustomers(100);
            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }
        public void Start()
        {
            var customers = generator.GetNewCustomers(10);
            var carts = new List<Cart>();
            foreach (var customer in customers)
            {
                var cart = new Cart(customer);
                foreach (var prod in generator.GetRandomProducts(10, 30))
                {
                    cart.Add(prod);
                }
                carts.Add(cart);
            }
            var cash = CashDesks[rnd.Next(CashDesks.Count - 1)]; // todo:
            foreach (var cart in carts)
            {
                cash.Enqueue(cart);
                carts.Remove(cart);
            }
        }
    }
}
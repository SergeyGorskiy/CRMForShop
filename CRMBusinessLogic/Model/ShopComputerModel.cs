using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRMBusinessLogic.Model
{
    public class ShopComputerModel
    {
        Generator generator = new Generator();
        Random rnd = new Random();
        private bool isWorking = false;
        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

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
            isWorking = true;
            Task.Run(() => CreateCarts(10, 1000));
            while (true)
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)];
                var money = cash.Dequeue();
            }
        }

        private void CreateCarts(int customerCounts, int sleep)
        {
            while (isWorking)
            {
                var customers = generator.GetNewCustomers(customerCounts);
                var carts = new Queue<Cart>();
                foreach (var customer in customers)
                {
                    var cash = CashDesks[rnd.Next(CashDesks.Count - 1)];
                    cash.Enqueue(carts.Dequeue());
                }
                Thread.Sleep(sleep);
            }
            
        }
    }
}
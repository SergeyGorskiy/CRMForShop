using System.Data.Entity;

namespace CRMBusinessLogic.Model
{
    public class CRMContext :DbContext
    {
        public CRMContext() : base("CRMShopDB") {}
        public DbSet<Check> Checks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<Seller> Sellers { get; set; }
    }

}


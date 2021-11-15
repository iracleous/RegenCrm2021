using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegenCrm.Model
{
    public class CrmDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=RegenCrm;Integrated Security=True");
            // optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=RegenCrm;User ID=sa;Password=passw0rd");

        }

    }
}

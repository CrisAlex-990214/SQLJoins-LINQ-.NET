using Microsoft.EntityFrameworkCore;
using SqlJoins_LinqC_.Entities;

namespace SqlJoins_LinqC_
{
    public class ShopDbContext(DbContextOptions opts) : DbContext(opts)
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Paul" },
                new Customer { Id = 2, Name = "Eva" },
                new Customer { Id = 3, Name = "Bob" }
                );

            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, StreetAddress = "4729 Sun Brook, East Royfort, WY 89467", CustomerId = 1 },
                new Address { Id = 2, StreetAddress = "25901 Bernardo Dam, Winstonfort, AK 84367-9199", CustomerId = 2 },
                new Address { Id = 3, StreetAddress = "Apt. 861 65067 Mose Loop, South Sandyfurt, CA 40038-8604" }
                );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Pinewood.CustomerManagement.Core.Entities;

namespace Pinewood.CustomerManagement.Core.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
                                : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(x=>x.Id);

            base.OnModelCreating(modelBuilder);

            //Seed Departments Table
            //modelBuilder.Entity<Customer>().HasData(
            //    new Customer {  Id = 1, Email = "test@gmail.com", Name = "test" });
        }
    }
}

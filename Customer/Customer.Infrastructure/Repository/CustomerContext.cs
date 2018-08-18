namespace Customer.Infrastructure.Repository
{
    using Microsoft.EntityFrameworkCore;
    using Customer.Domain.Entity;
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) :
               base(options)
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("customers");

        }
    }
}

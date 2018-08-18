namespace Customer.Infrastructure.Repository
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class DbInitializer
    {
        private readonly CustomerContext _context;

        public DbInitializer(CustomerContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task Seed()
        {
            SeedCustomers();
            await _context.SaveChangesAsync();
        }


        public void SeedCustomers()
        {
            if (_context.Customers.Any(p => p.Dni == "44444568")) return;

            _context.Customers.Add(new Domain.Entity.Customer
            {
                FirstName = "Henry",
                LastName = "Fuentes",
                Dni = "44444568",
                Active = true,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            });

            if (_context.Customers.Any(p => p.Dni == "44444569")) return;

            _context.Customers.Add(new Domain.Entity.Customer
            {
                FirstName = "Juan",
                LastName = "Perez",
                Dni = "44444569",
                Active = true,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            });
        }
    }
}

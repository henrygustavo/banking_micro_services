namespace Customer.Infrastructure.Repository
{
    using Customer.Domain.Repository;

    public class CustomerUnitOfWork : ICustomerUnitOfWork
    {
        private readonly CustomerContext _context;

        public CustomerUnitOfWork(CustomerContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);

        }

        public ICustomerRepository Customers { get; }
       
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

  
}

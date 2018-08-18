namespace Customer.Infrastructure.Repository
{
    using Common.Infrastructure.Repository;
    using Customer.Domain.Repository;
    using Customer.Domain.Entity;

    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext context)
         : base(context)
        {

        }
    }
}

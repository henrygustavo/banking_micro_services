namespace Customer.Domain.Repository
{
    using Common.Domain.Repository;

    public interface ICustomerUnitOfWork : IUnitOfWork
    {
        ICustomerRepository Customers { get; }
    }
}

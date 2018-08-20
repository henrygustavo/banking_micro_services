namespace Customer.Domain.Repository
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        int Complete();
    }
}

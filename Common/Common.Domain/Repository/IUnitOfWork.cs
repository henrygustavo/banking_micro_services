namespace Common.Domain.Repository
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}

namespace Customer.Application.Service
{
    using AutoMapper;
    using Common.Application.Dto;
    using Customer.Application.Dto;
    using Customer.Domain.Repository;
    using Customer.Domain.Service;
    using Customer.Domain.Entity;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerApplicationService : ICustomerApplicationService
    {
        private readonly ICustomerUnitOfWork _unitOfWork;

        private readonly ICustomerDomainService _customerDomainService;
        public CustomerApplicationService(ICustomerUnitOfWork unitOfWork,
            ICustomerDomainService customerDomainService)
        {
            _unitOfWork = unitOfWork;
            _customerDomainService = customerDomainService;
        }

        public CustomerOutputDto Get(int id)
        {
            return Mapper.Map<CustomerOutputDto>(_unitOfWork.Customers.Get(id));
        }

        public IList<CustomerOutputDto> GetAll()
        {
            return Mapper.Map<List<CustomerOutputDto>>(_unitOfWork.Customers.GetAll());
        }

        public PaginationOutputDto GetAll(int page, int pageSize, string sortBy, string sortDirection)
        {
            var entities = _unitOfWork.Customers.GetAll(page, pageSize, sortBy, sortDirection).ToList();
            
            var pagedRecord = new PaginationOutputDto
            {
                Content = Mapper.Map<List<CustomerOutputDto>>(entities),
                TotalRecords = _unitOfWork.Customers.CountGetAll(),
                CurrentPage = page,
                PageSize = pageSize
            };

            return pagedRecord;
        }

        public int Add(CustomerInputDto entity)
        {
            var customer = Mapper.Map<Customer>(entity);

            _unitOfWork.Customers.Add(customer);

            _unitOfWork.Complete();

            return customer.Id;
        }

        public int Update(int id, CustomerInputDto entity)
        {
            var customer = _unitOfWork.Customers.Get(id);
            _unitOfWork.Customers.Update(customer);
            _unitOfWork.Complete();

            return customer?.Id ?? 0;
        }

        public int Remove(int id)
        {
            var customer = _unitOfWork.Customers.Get(id);
            _unitOfWork.Customers.Remove(customer);

            return _unitOfWork.Complete();

        }
    }
}
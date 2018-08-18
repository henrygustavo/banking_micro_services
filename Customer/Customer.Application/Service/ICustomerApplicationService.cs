namespace Customer.Application.Service
{
    using Common.Application.Service;
    using Customer.Application.Dto;
    public interface ICustomerApplicationService: IBaseApplicationService<CustomerInputDto, CustomerOutputDto>
    {
    }
}

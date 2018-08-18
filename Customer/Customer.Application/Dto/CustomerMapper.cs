namespace Customer.Application.Dto
{
    using AutoMapper;
    using Customer.Domain.Entity;
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerInputDto>().ReverseMap();

            CreateMap<Customer, CustomerOutputDto>()
                .ForMember(destination => destination.FullName,
                    opts => opts.MapFrom(source => $"{source.LastName} {source.FirstName}"));

            
        }
    }

    
}

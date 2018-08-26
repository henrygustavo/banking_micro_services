namespace Customer.Api.Controllers
{
    using Customer.Application.Dto;
    using Customer.Application.Service;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/customers")]
    [Authorize(AuthenticationSchemes = "TestKey")]
    public class CustomersController : Controller
    {
        private readonly ICustomerApplicationService _customerApplicationService;

        public CustomersController(ICustomerApplicationService customerApplicationService)
        {
            _customerApplicationService = customerApplicationService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginationOutputDto), 200)]
        public IActionResult GetAll(int page = 1, int pageSize = 10, string sortBy = "lastName", string sortDirection = "asc")
        {
            return Ok(_customerApplicationService.GetAll(page, pageSize, sortBy, sortDirection));
        }
    }
}
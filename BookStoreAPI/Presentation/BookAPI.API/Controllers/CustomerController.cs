using BookAPI.Application.Features.Commands.Customer.CreateCustomer;
using BookAPI.Application.Features.Commands.Customer.LoginCustomer;
using BookAPI.Application.Features.Queries.GetAllCustomers;
using BookAPI.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookAPI.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "admin")]
    public class CustomerController : ControllerBase
    {
        private ICustomerReadRepository customerReadRepository;
        private ICustomerWriteRepository customerWriteRepository;
        readonly IMediator mediator;
        public CustomerController(ICustomerReadRepository customerRead, ICustomerWriteRepository customerWrite, IMediator mediator)
        {
            this.customerReadRepository = customerRead;
            this.customerWriteRepository = customerWrite;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers([FromQuery] GetAllCustomersQueryRequest getAllCustomersQueryRequest)
        {
            List<GetAllCustomersQueryResponse> response = await mediator.Send(getAllCustomersQueryRequest);
            return Ok(response);
        }

        [HttpGet("{id}")]
        //FromRoute
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(customerReadRepository.GetByIdAsync(id)); 
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommandRequest createCustomerCommandRequest )
        {
           CreateCustomerCommandResponse response = await mediator.Send(createCustomerCommandRequest);
            if(response.IsSuccess) 
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            return BadRequest();
        }
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCustomerCommandRequest loginCustomerCommandRequest)
        {
            LoginCustomerCommandResponse response = await mediator.Send(loginCustomerCommandRequest);

            return Ok(response);
        }
    }
}

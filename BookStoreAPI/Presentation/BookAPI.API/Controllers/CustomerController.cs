using BookAPI.Application.Features.Commands.CreateCustomer;
using BookAPI.Application.Features.Queries.GetAllCustomers;
using BookAPI.Application.Repositories;
using BookAPI.Domain.Entites;
using BookAPI.Persistance.Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace BookAPI.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerReadRepository customerRead;
        private ICustomerWriteRepository customerWrite;
        readonly IMediator mediator;
        public CustomerController(ICustomerReadRepository customerRead, ICustomerWriteRepository customerWrite, IMediator mediator)
        {
            this.customerRead = customerRead;
            this.customerWrite = customerWrite;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            GetAllCustomersQueryRequest getAllCustomersQueryRequest=new GetAllCustomersQueryRequest();
            List<GetAllCustomersQueryResponse> response = await mediator.Send(getAllCustomersQueryRequest);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(customerRead.GetById(id)); 
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(CreateCustomerCommandRequest createCustomerCommandRequest )
        {
           CreateCustomerCommandResponse response = await mediator.Send(createCustomerCommandRequest);
            if(response.IsSuccess) 
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            return BadRequest();

        }
    }
}

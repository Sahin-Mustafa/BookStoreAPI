using BookAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        public CustomerController(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }

        [HttpGet]
        public void GetCustomers()
        {
            _customerWriteRepository.AddRange(new()
            {
                new(){Id= 1},
                new(){Id= 2},

            });
            _customerWriteRepository.Save();

        }
    }
}

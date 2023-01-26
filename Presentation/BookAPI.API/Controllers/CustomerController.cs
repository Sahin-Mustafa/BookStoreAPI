using BookAPI.API.Model;
using BookAPI.Application.Repositories;
using BookAPI.Domain.Entites;
using BookAPI.Persistance.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookAPI.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerReadRepository customerRead;
        private ICustomerWriteRepository customerWrite;
        public CustomerController(ICustomerReadRepository customerRead, ICustomerWriteRepository customerWrite)
        {
            this.customerRead = customerRead;
            this.customerWrite = customerWrite;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(customerRead.GetAll().ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(customerRead.GetById(id)); 
        }
        [HttpPost]
        public IActionResult AddCustomer(ModelAddCustomer model)
        {
            Customer customer = customerRead.GetSingle(c => c.Email == model.Email && c.Password == model.Password);

            if(customer is null)
            {
                customer.Email = model.Email;
                customer.Password = model.Password;
                bool result = customerWrite.Add(customer);
                customerWrite.Save();
                
                return Created("", customer);
            }
            return BadRequest();

        }
    }
}

using BookAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Application.Features.Commands.Customer.LoginCustomer
{
    public class LoginCustomerCommandResponse
    {
        public Token Token { get; set; } 
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Application.Features.Commands.Customer.LoginCustomer
{
    public class LoginCustomerCommandRequest :IRequest<LoginCustomerCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

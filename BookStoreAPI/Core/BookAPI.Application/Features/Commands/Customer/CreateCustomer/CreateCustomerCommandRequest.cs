using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Application.Features.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandRequest : IRequest<CreateCustomerCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

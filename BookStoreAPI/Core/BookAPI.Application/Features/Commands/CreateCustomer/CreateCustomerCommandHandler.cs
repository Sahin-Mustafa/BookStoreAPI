using BookAPI.Application.Repositories;
using BookAPI.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Application.Features.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        private ICustomerReadRepository customerRead;
        private ICustomerWriteRepository customerWrite;

        public CreateCustomerCommandHandler(ICustomerReadRepository customerRead, ICustomerWriteRepository customerWrite)
        {
            this.customerRead = customerRead;
            this.customerWrite = customerWrite;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            Customer isHave = customerRead.GetSingle(c => c.Email == request.Email && c.Password == request.Password);

            if (isHave is null)
            {
                Customer customer = new Customer
                {
                    Email = request.Email,
                    Password = request.Password
                };
                customerWrite.Add(customer);
                int result = customerWrite.Save();

                return new() { IsSuccess = true };


            }
            return new() { IsSuccess = false };
        }
    }
}

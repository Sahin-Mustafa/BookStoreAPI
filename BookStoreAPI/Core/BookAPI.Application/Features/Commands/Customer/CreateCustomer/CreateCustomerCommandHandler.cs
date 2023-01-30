﻿using BookAPI.Application.Repositories;
using C=BookAPI.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Application.Features.Commands.Customer.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        private ICustomerReadRepository customerReadRepository;
        private ICustomerWriteRepository customerWriteRepository;

        public CreateCustomerCommandHandler(ICustomerReadRepository customerRead, ICustomerWriteRepository customerWrite)
        {
            this.customerReadRepository = customerRead;
            this.customerWriteRepository = customerWrite;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            C.Customer isHave = customerReadRepository.GetSingle(c => c.Email == request.Email && c.Password == request.Password);

            if (isHave is null)
            {
                C.Customer customer = new C.Customer
                {
                    Email = request.Email,
                    Password = request.Password
                };
                customerWriteRepository.Add(customer);
                int result = customerWriteRepository.Save();

                return new() { IsSuccess = true };


            }
            return new() { IsSuccess = false };
        }
    }
}
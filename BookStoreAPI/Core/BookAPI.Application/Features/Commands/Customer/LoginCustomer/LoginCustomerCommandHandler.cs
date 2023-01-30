using BookAPI.Application.Abstraction.Token;
using BookAPI.Application.Repositories;
using C=BookAPI.Domain.Entites;
using MediatR;
using System.Security.Cryptography.X509Certificates;
using BookAPI.Application.Exceptions;

namespace BookAPI.Application.Features.Commands.Customer.LoginCustomer
{
    public class LoginCustomerCommandHandler : IRequestHandler<LoginCustomerCommandRequest, LoginCustomerCommandResponse>
    {
        readonly ICustomerReadRepository customerReadRepository;
        readonly ICustomerWriteRepository customerWriteRepository;
        readonly ITokenHandler tokenHandler;

        public LoginCustomerCommandHandler(ITokenHandler tokenHandler, ICustomerWriteRepository customerWriteRepository, ICustomerReadRepository customerReadRepository)
        {
            this.tokenHandler = tokenHandler;
            this.customerWriteRepository = customerWriteRepository;
            this.customerReadRepository = customerReadRepository;
        }

        public async Task<LoginCustomerCommandResponse> Handle(LoginCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            C.Customer customer = customerReadRepository.GetSingle(c => c.Email == request.Email && c.Password == request.Password);
            if (customer == null)
                 throw new NotFoundCustomerException();
            
            return new() { Token=tokenHandler.CreateAccessToken() };
        }
    }
}

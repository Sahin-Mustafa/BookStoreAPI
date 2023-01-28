using BookAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Application.Features.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQueryRequest, List<GetAllCustomersQueryResponse>>
    {
        readonly ICustomerReadRepository customerReadRepository;
        public GetAllCustomersQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            this.customerReadRepository = customerReadRepository;
        }

        public async Task<List<GetAllCustomersQueryResponse>> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllCustomersQueryResponse> customers = customerReadRepository.GetAll().Select(customer => new GetAllCustomersQueryResponse
            {
                Id = customer.Id,
                Fullname = customer.Fullname,
                Email = customer.Email,
                IsDelete = customer.IsDelete,
                CreatedTime = customer.CreatedTime
            }).ToList();
            return customers;
        }
    }
}

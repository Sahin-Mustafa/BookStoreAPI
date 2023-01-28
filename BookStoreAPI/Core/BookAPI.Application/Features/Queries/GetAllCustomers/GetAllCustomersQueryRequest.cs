using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Application.Features.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryRequest : IRequest<List<GetAllCustomersQueryResponse>>
    {
        //This place is empty as all customers are requested
    }
}

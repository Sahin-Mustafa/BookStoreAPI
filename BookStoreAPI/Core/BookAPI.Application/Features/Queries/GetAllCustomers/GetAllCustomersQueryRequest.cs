using MediatR;

namespace BookAPI.Application.Features.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryRequest : IRequest<List<GetAllCustomersQueryResponse>>
    {
        //This place is empty as all customers are requested
    }
}
